using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AzureRepository.Common.Azure.Common.Entities;
using AzureRepository.Common.Azure.Entities;
using AzureRepository.Common.Azure.Entity;
using AzureRepository.Common.Azure.ServiceBase;
using AzureRepository.Common.Azure.StorageAccount;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic.CompilerServices;

namespace ExampleUsage
{
    public class Startup
    {
        public IConfiguration _config { get; }
        public Startup(IConfiguration config)
        {
            this._config = config;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            ConfigureAzureRepositoryServices(services);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
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

        public void ConfigureAzureRepositoryServices(IServiceCollection services)
        {
            services.AddScoped<IAzureRepositoryService<TrackingRegistryEntity>>(factory =>
            {
                return new AzureRepositoryService<TrackingRegistryEntity>(_config, "importShipmentConfiguration");
            });
            services.AddScoped<IAzureRepositoryService<ImportShipmentConfigurationEntity>>(factory =>
            {
                return new AzureRepositoryService<ImportShipmentConfigurationEntity>(_config, "importShipmentConfiguration");
            });
        }
    }
}

