using Microsoft.Extensions.DependencyInjection;
using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using CommonServiceLocator;
using Autofac.Extras.CommonServiceLocator;
using TradeManager.Service.DomainEvents.Processing;
using Quartz.Impl;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TradeManager.Servuce.Infrastructure.Quartz;
using Quartz;
using TradeManager.Servuce.Infrastructure.Processing.InternalCommand;
using TradeManager.Service.Configuration;
using TradeManager.Service.Infrastructure.Database;
using TradeManager.Servuce.Infrastructure.SeedWork;

namespace TradeManager.Servuce.Infrastructure
{
    public class ApplicationStartup
    {
        public static IServiceProvider Inizialize(IServiceCollection services, IExecutionContextAccessor executionContextAccessor, bool runQuartz = true)
        {
            if (runQuartz)
            {
                StartJobScheduler(executionContextAccessor);
            }

            return RegisterServiceProvider(services, executionContextAccessor);
        }

        private static IServiceProvider RegisterServiceProvider(IServiceCollection services, IExecutionContextAccessor executionContextAccessor)
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.Populate(services);

            containerBuilder.RegisterModule(new MediatorModule());
            containerBuilder.RegisterModule(new ProcessingModule());


            containerBuilder.RegisterInstance(executionContextAccessor);

            // need register moduls
            // in this context the module we need is the mediator to process the internal domain commands


            var containerBuilded = containerBuilder.Build();

            ServiceLocator.SetLocatorProvider(() => new AutofacServiceLocator(containerBuilded));

            var autofacServiceProvider = new AutofacServiceProvider(containerBuilded);

            CompositionRoot.SetContainer(containerBuilded);

            return autofacServiceProvider;
        }

        private static void StartJobScheduler(IExecutionContextAccessor executionContextAccessor)
        {
            var schedulerFactory = new StdSchedulerFactory();
            var scheduler = schedulerFactory.GetScheduler().GetAwaiter().GetResult();

            var container = new ContainerBuilder();

            container.RegisterModule(new QuartzModule());
            container.RegisterModule(new MediatorModule());
            container.RegisterModule(new ProcessingModule());

            container.RegisterInstance(executionContextAccessor);
            container.Register(c =>
            {
                var dbContextOptionsBuilder = new DbContextOptionsBuilder<UpsLightContext>();
              
                dbContextOptionsBuilder
                    .ReplaceService<IValueConverterSelector, StronglyTypedIdValueConverterSelector>();

                return new UpsLightContext(dbContextOptionsBuilder.Options);
            }).AsSelf().InstancePerLifetimeScope();


            scheduler.JobFactory = new JobFactory(container.Build());

            scheduler.Start().GetAwaiter().GetResult();

            // https://www.quartz-scheduler.net/documentation/quartz-2.x/tutorial/crontriggers.html 
            var processInternalCommandsJob = JobBuilder.Create<ProcessInternalCommandsJob>().Build();
            var triggerCommandsProcessing =
                TriggerBuilder
                    .Create()
                    .StartNow()
                    .WithCronSchedule("0/15 * * ? * *")
                    .Build();
            scheduler.ScheduleJob(processInternalCommandsJob, triggerCommandsProcessing).GetAwaiter().GetResult();

        }
    }
}
