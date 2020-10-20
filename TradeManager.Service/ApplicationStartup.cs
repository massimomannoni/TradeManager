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
using TradeManager.Service.SeedWork;
using TradeManager.Infrastructure.Quartz;
using Quartz;
using TradeManager.Service.Processing.Events;

namespace TradeManager.Service
{
    public class ApplicationStartup
    {
        public static IServiceProvider Inizialize(IServiceCollection services)
        {
            return RegisterServiceProvider(services);
        }

        private static IServiceProvider RegisterServiceProvider(IServiceCollection services)
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.Populate(services);

            containerBuilder.RegisterModule(new MediatorModule());
            containerBuilder.RegisterModule(new ProcessingModule());

            // need register moduls
            // in this context the module we need is the mediator to process the internal domain commands


            var containerBuilded = containerBuilder.Build();

            ServiceLocator.SetLocatorProvider(() => new AutofacServiceLocator(containerBuilded));

            var autofacServiceProvider = new AutofacServiceProvider(containerBuilded);

            CompositionRoot.SetContainer(containerBuilded);

            return autofacServiceProvider;
        }

        private static void StartJobScheduler()
        {
            var schedulerFactory = new StdSchedulerFactory();
            var scheduler = schedulerFactory.GetScheduler().GetAwaiter().GetResult();

            var container = new ContainerBuilder();

            container.RegisterModule(new QuartzModule());
            container.RegisterModule(new MediatorModule());
            container.RegisterModule(new ProcessingModule());

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
                    .WithCronSchedule("0/5 * * ? * *")
                    .Build();
            scheduler.ScheduleJob(processInternalCommandsJob, triggerCommandsProcessing).GetAwaiter().GetResult();

        }
    }
}
