using Microsoft.Extensions.DependencyInjection;
using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using CommonServiceLocator;
using Autofac.Extras.CommonServiceLocator;

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
