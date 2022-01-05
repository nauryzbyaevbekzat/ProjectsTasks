using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace TestAkvelon
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            //The connection string is in the file appsettings.json , 
            // get the connection string from the config file
            string connection = Configuration.GetConnectionString("DefaultConnection");
            // add the context as ApplicationContext  a service to the application
            services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(connection));
            //Web API controllers required for the operation are performed using the services.AddControllers() method
            services.AddControllers();
            
            services.AddSwaggerGen(options => {

                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Swagger Demo API",
                    Description = "Demo API",
                    Version = "v1"
                        
                });
             }
            );
        }

       public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // if the application is under development
            if (env.IsDevelopment())
            {   // then display information about the error, if there is an error
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            // add routing capabilities
            app.UseRouting();


            // set the addresses to be processed
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers(); // no routes defined
            });
            //API documentation
            //https://localhost:44326/swagger/index.html 
            app.UseSwagger();
            app.UseSwaggerUI(
            
                options => {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger Demo Api");
                }
            ); 
        }
    }
}
