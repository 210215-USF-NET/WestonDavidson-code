using Amazon.S3;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToHBL;
using ToHDL;

namespace ToHREST
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

            services.AddControllers();
            services.AddCors(
                options =>
                {
                    options.AddPolicy(
                        name: "ToHCorsPolicy",
                        builder =>
                        {
                            // when you build your frontend, set this as the angular website origin domain,
                            // you might also need to allow the third party api you're using to access your stuff
                            builder.WithOrigins("*")
                            .AllowAnyMethod()
                            .AllowAnyHeader();
                        }
                        );
                }
                );

            var options = Configuration.GetAWSOptions();
            IAmazonS3 client = options.CreateServiceClient<IAmazonS3>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ToHREST", Version = "v1" });
            });
            services.AddDbContext<HeroDBContext>(options => options.UseNpgsql(Configuration.GetConnectionString("HeroDB")));
            //this is where you declare all the different stuff you need to implement - all the bl/dl dependency injections
            //this basically says - herorepodb has a dependency on an iherorepository
            services.AddScoped<IHeroRepository, HeroRepoDB>();
            services.AddScoped<IHeroBL, HeroBL>();

            //add aws services to our system - now our controllers can access these services as needed
            services.AddAWSService<IAmazonS3>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ToHREST v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("ToHCorsPolicy");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
