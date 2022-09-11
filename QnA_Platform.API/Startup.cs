using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using QnA_Platform.Application;
using QnA_Platform.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QnA_Platform.API
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

            services.AddControllers().AddNewtonsoftJson(options =>
             options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
              );


            services.AddApplicationServices();
            services.AddPersistenceServices(Configuration);
            
             services.AddCors(options =>
               {
                   options.AddPolicy("Open", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
              });
            services.AddSwaggerGen(c =>
                   c.SwaggerDoc("v1", new OpenApiInfo { Title = "QnAPlatformAPI", Version = "v1" })
                );



            // usser name :yzfbsgekawwrsf:
            // passwotd of db : d3bc50e511b48755aeaba14f3cab95b6de7dd4fb53c2adfb9c4e971a301ad2aa
            // port : 5432
            // server : ec2-52-200-5-135.compute-1.amazonaws.com
            // database name : d7fq6l2l431vfo
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {

                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "QnAPlatformAPI v1");
                    
                });
            }

            app.UseHttpsRedirection();

            app.UseRouting();


            app.UseCors("Open");
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
