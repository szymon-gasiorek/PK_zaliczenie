using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PK_zaliczenie_web_1.Models;

namespace PK_zaliczenie_web_1
{
    public class Startup
    {
        private IConfiguration _config;

        public Startup(IConfiguration config)
        {
            _config = config;   
        }

      
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContextPool<AppDbContext>
                (options => options.UseSqlServer(_config.GetConnectionString("UnitDBConnsection")));

            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>();

           

            services.AddMvc().AddXmlSerializerFormatters();

            services.AddScoped<IUnitsRepository, SQLUnitRepository> ();
            services.AddScoped<ISudokuRules, SudokuRules>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env )
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseStatusCodePagesWithReExecute("/Error/{0}");
            }

          
            app.UseStaticFiles();
            app.UseAuthentication();
           
            app.UseMvc(routes => {
                routes.MapRoute("default", "{controller=Home}/{action=Index}");

            });

        }
    }
}
