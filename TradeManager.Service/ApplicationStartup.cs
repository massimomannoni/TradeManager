using Microsoft.Extensions.DependencyInjection;
using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using CommonServiceLocator;
using Autofac.Extras.CommonServiceLocator;
using TradeManager.Service.DomainEvents.Processing;

using TradeManager.Service.Configuration;
using TradeManager.Service.Infrastructure.Database;

namespace TradeManager.Service.Infrastructure
{
    public class ApplicationStartup
    {
        public static IServiceProvider Inizialize(IServiceCollection services, string connectionString, IExecutionContextAccessor executionContextAccessor, bool runQuartz = true)
        {

            return RegisterServiceProvider(services, connectionString, executionContextAccessor);
        }

        private static IServiceProvider RegisterServiceProvider(IServiceCollection services, string connectionString, IExecutionContextAccessor executionContextAccessor)
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.Populate(services);

            containerBuilder.RegisterModule(new MediatorModule());
            containerBuilder.RegisterModule(new DataAccessModule(connectionString));


            containerBuilder.RegisterInstance(executionContextAccessor);


            var containerBuilded = containerBuilder.Build();

            ServiceLocator.SetLocatorProvider(() => new AutofacServiceLocator(containerBuilded));

            var autofacServiceProvider = new AutofacServiceProvider(containerBuilded);

            CompositionRoot.SetContainer(containerBuilded);

            return autofacServiceProvider;
        }
    }
}
