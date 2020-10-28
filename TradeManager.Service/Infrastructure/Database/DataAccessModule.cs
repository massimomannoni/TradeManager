using Autofac;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TradeManager.Service.Infrastructure.Domain.Trades;
using TradeManager.Service.Infrastructure.SeedWork;
using TradeManager.Service.Trades;

namespace TradeManager.Service.Infrastructure.Database
{
    public class DataAccessModule : Autofac.Module
    {

        private readonly string _connectionString;

        public DataAccessModule(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType<TradeServiceHandler>()
                .As<ITradeService>()
                .InstancePerLifetimeScope();

            builder
                .Register(c =>
                {
                    var dbContextOptionsBuilder = new DbContextOptionsBuilder<UpsLightContext>();
                    dbContextOptionsBuilder.UseSqlServer(_connectionString);
                    dbContextOptionsBuilder
                        .ReplaceService<IValueConverterSelector, StronglyTypedIdValueConverterSelector>();

                    return new UpsLightContext(dbContextOptionsBuilder.Options);
                })
                .AsSelf()
                .As<DbContext>()
                .InstancePerLifetimeScope();
        }
    }
}