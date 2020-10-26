using Microsoft.Extensions.DependencyInjection;
using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using CommonServiceLocator;
using Autofac.Extras.CommonServiceLocator;
using TradeManager.Service.DomainEvents.Processing;

using TradeManager.Service.Configuration;

namespace TradeManager.Service.Infrastructure
{
    public class ApplicationStartup
    {
        public static IServiceProvider Inizialize(IServiceCollection services, IExecutionContextAccessor executionContextAccessor, bool runQuartz = true)
        {

            return RegisterServiceProvider(services, executionContextAccessor);
        }

        private static IServiceProvider RegisterServiceProvider(IServiceCollection services, IExecutionContextAccessor executionContextAccessor)
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.Populate(services);

            containerBuilder.RegisterModule(new MediatorModule());


            containerBuilder.RegisterInstance(executionContextAccessor);

            // need register moduls
            // in this context the module we need is the mediator to process the internal domain commands

            var containerBuilded = containerBuilder.Build();

            ServiceLocator.SetLocatorProvider(() => new AutofacServiceLocator(containerBuilded));

            var autofacServiceProvider = new AutofacServiceProvider(containerBuilded);

            CompositionRoot.SetContainer(containerBuilded);

            return autofacServiceProvider;
        }
    }
}
