using System.Reflection;
using Autofac;
using MediatR;
using TradeManager.Service.Configuration.Commands;
using TradeManager.Service.Configuration.Processing;
using TradeManager.Servuce.Infrastructure.Processing;
using TradeManager.Servuce.Infrastructure.Processing.InternalCommand;

namespace TradeManager.Service.DomainEvents.Processing
{
    public class ProcessingModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType<DomainEventsDispatcher>()
                   .As<IDomainEventsDispatcher>()
                   .InstancePerLifetimeScope();

            builder.RegisterGenericDecorator(
                typeof(DomainEventsDispatcherNotificationHandlerDecorator<>),
                typeof(INotificationHandler<>));

            builder.RegisterGenericDecorator(
                typeof(UnitOfWorkCommandHandlerDecorator<>),
                typeof(ICommandHandler<>));

            builder.RegisterGenericDecorator(
                typeof(UnitOfWorkCommandHandlerWithResultDecorator<,>),
                typeof(ICommandHandler<,>));

            builder.RegisterType<CommandsDispatcher>()
                .As<ICommandsDispatcher>()
                .InstancePerLifetimeScope();

            builder.RegisterType<CommandsScheduler>()
                .As<ICommandsScheduler>()
                .InstancePerLifetimeScope();
        }
    }
}