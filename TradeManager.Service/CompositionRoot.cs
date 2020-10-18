﻿using Autofac;

namespace TradeManager.Service
{
    public static class CompositionRoot
    {
        private static Autofac.IContainer _container;

        public static void SetContainer(Autofac.IContainer container)
        {
            _container = container;
        }

        internal static ILifetimeScope BeginLifetimeScope()
        {
            return _container.BeginLifetimeScope();
        }
    }
}
