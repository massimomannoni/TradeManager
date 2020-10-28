using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TradeManager.API.Configuration;
using TradeManager.Service.Configuration;
using TradeManager.Service.Infrastructure.Database;
using TradeManager.Service.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using TradeManager.Service.Infrastructure.Domain.Trades;
using TradeManager.Service.Trades.CreateTrade;
using TradeManager.Service.Trades;

namespace TradeManager.Api
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        private const string _connectionString = "UpsLightDb";
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;

            var builder = new ConfigurationBuilder()
                  .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                  .AddEnvironmentVariables();

            _configuration = builder.Build();
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            var connectionString = _configuration.GetConnectionString(_connectionString);

            services.AddHttpContextAccessor();
            var serviceProvider = services.BuildServiceProvider();

            IExecutionContextAccessor executionContextAccessor = new ExecutionContextAccessor(serviceProvider.GetService<IHttpContextAccessor>());


            // pass the services to Service project
            return ApplicationStartup.Inizialize(services, connectionString, executionContextAccessor);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
