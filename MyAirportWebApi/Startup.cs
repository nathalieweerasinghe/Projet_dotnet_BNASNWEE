using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using BNASNWEE.MyAirport.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace MyAirport.WebApi
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
            services.AddDbContext<MyAirportContext>(option =>
            option.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=MyAirport;Integrated Security=True"));
            services.AddControllers();//.AddNewtonSoftJson( o =>
            /*{
                o.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            ]);*/
                //Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new OpenApiInfo
                    {
                        Title = "My Api",
                        Version = "v1",
                        Description = "Gestionnaire d'aéroport super top",
                    });
                });
            }
    
            
            // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
            public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
            {
                // Enable middleware to serve generated Swagger as JSON endpoint
                app.UseSwagger();

                // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.)
                // Specifying the Swagger JSON endpoint.
                app.UseSwaggerUI(c =>
               {
                   c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyAirportApi V1")
               });
                if (env.IsDevelopment())
                {
                    app.UseDeveloperExceptionPage();
                }

                app.UseHttpsRedirection();

                app.UseRouting();

                app.UseAuthorization();

                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });
            }
        }
}
