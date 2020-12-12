using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.OpenApi.Models;
using ImpactaBank.API.Interface;
using ImpactaBank.API.Service;
using ImpactaBank.API.Repository;

namespace ImpactaBank.API
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

            services.AddSwaggerGen(swagger => 
            {
                swagger.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Version = "v1",
                    Title = "Impacta - ImpactaBank.API V1",
                    Description = "ImpactaBank.API",
                    Contact = new OpenApiContact()
                    {
                        Name = "Dan",
                        Email = "danlustosa@gmail.com",
                        Url = new System.Uri("http://www.danlustosa.com.br")
                    }
                });
            });


            services.AddSingleton<IAccountService, AccountService>();
            services.AddSingleton<ICustomerService, CustomerService>();
            services.AddSingleton<ICustomerRepository, CustomerRepository>();
            services.AddSingleton<IAccountRepository, AccountRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(c => 
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ImpactaBank.API");
                c.DocumentTitle = "ImpactaBank.API";
                c.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
