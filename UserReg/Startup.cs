using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UserReg.Models;
using System.Data.SqlClient;

using Microsoft.EntityFrameworkCore.Storage;
//using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
//using Microsoft.EntityFrameworkCore.Storage;

namespace UserReg
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
            
            // string con = @"Server=tcp:user-registration-db.database.windows.net,1433;Initial Catalog=Test_DB;Persist Security Info=False;User ID=raviranjan;Password=Oncall!1989;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            //string xmlStr = con.Replace("\\\"", "\"");
            var providerName = "System.Data.SqlClient";
           // var db = Database.  .OpenConnectionString(con, providerName);
            //services.AddDbContext<ApplicationUser>(options => options.UseSqlServer(con));
            services.AddDbContext<ApplicationUser>(options => options.UseSqlServer(Configuration.GetConnectionString("Myconnection")));
            //services.AddControllersWithViews();


            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
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
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Registration}/{action=Create}/{id?}");
            });
        }
    }
}
