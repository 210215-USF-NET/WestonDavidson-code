using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToHDL;
using Microsoft.EntityFrameworkCore;
using ToHBL;
using ToHMVC.Models;

namespace ToHMVC
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
            //the objects your application will be dependent on
            services.AddControllersWithViews();
            //SOMETHING WENT WRONG HERE
            services.AddDbContext<HeroDBContext>(options => options.UseNpgsql(Configuration.GetConnectionString("HeroDB")));
            //this is where you declare all the different stuff you need to implement - all the bl/dl dependency injections
            //this basically says - herorepodb has a dependency on an iherorepository
            services.AddScoped<IHeroRepository, HeroRepoDB>();
            services.AddScoped<IHeroBL, HeroBL>();
            services.AddScoped<IMapper, Mapper>();
                //singleton - just going to use one instance of that object
                //transient - every single time we use that service, we create a new object for the service 
                //scoped - for every request/response, we create a new instance of that service
                //with scope, we just create objects as we need them per request from client
                //we want to use scoped so that every request/response is independent of one another
                //transient would mean too much overhead

            //need to run these commands after:
            //dotnet ef migrations add initial -c HeroDBContext --startup-project ../ToHMVC - run from inside ToHDL
            //dotnet ef database update --startup-project ../ToHMVC
            //probably worth using dbeaver for P1 according to marielle
            //you can work with multiple database vendors in dbeaver. can do multiple db dialects
            // to connect, make new connection, choose postgreSQL, put in server/host, then user/default database, then password from elephantSQL
            // once finished, connect, and the tables/columns should be generated!
            // some things might look weird in database, you can use onmodelcreating to change things if u really want to
            // we can cross complications on the way efcore scaffolded models later
            // but outside of that, that's how we create a code-first database!
            // we will need to seed our data in our dbcontext
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
