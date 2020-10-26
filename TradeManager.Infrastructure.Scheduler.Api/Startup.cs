using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Coravel;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TradeManager.Infrastructure.Scheduler.Api.Processing;
using TradeManager.Infrastructure.Scheduler.Database;

namespace TradeManager.Infrastructure.Scheduler.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddScheduler();

            services.AddTransient<UpdateAnalytics>();

            services.AddDbContext<UpsLightJobContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("UpsLightJobDb")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
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

            var provider = app.ApplicationServices;
            provider.UseScheduler(scheduler =>
            {
                // add invocables
                scheduler.Schedule<UpdateAnalytics>()
                .EveryMinute()
                .Weekday();
            });

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
