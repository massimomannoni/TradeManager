using System.Reflection;
using Autofac;
using MediatR;
using TradeManager.Service.Configuration.Commands;
using TradeManager.Service.Configuration.Processing;
using TradeManager.Service.Processing;
using TradeManager.Service.Processing.Events;

namespace TradeManager.Service.DomainEvents.Processing
{
    public class ProcessingModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
 
         

            builder.RegisterType<CommandsDispatcher>()
                .As<ICommandsDispatcher>()
                .InstancePerLifetimeScope();

            builder.RegisterType<CommandsScheduler>()
                .As<ICommandsScheduler>()
                .InstancePerLifetimeScope();
        }
    }
}