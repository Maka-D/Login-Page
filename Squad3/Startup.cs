using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Squad3.AppService.PasswordHashAppService;
using Squad3.AppService.UserFirstDetailsAppService;
using Squad3.AppService.UserRegistrationAppService;
using Squad3.AppService.UsersInfoAppService;
using Squad3.EntityFramework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace Squad3
{
    public class Startup
    {
        private readonly IConfiguration _config;
        public Startup(IConfiguration config)
        {
            _config = config;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IFirstDetailsInfo, FirstDetailsInfo>();
            services.AddTransient<IUsersInfo, UsersInfo>();
            services.AddTransient<IPasswordHash, PasswordHash>();
            services.AddTransient<IUsers, Users>();
            services.AddDbContextPool<AppDbContext>(options => options.UseSqlServer(_config.GetConnectionString("OurDb")));
            services.AddMvc();
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=User}/{action=Index}/{Id?}");
            });
        }
    }
}
