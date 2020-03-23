using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AzureRepository.Common.Azure.Common.Entities;
using AzureRepository.Common.Azure.Entities;
using AzureRepository.Common.Azure.Entity;
using AzureRepository.Common.Azure.ServiceBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;


namespace ExampleUsage.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsageController : ControllerBase
    {

        private static IConfiguration _config;

        private readonly IAzureRepositoryService<TrackingRegistryEntity> _trackingRepository;
        private readonly IAzureRepositoryService<ImportShipmentConfigurationEntity> _importShipmentRepository;
        public UsageController(IConfiguration config, IAzureRepositoryService<TrackingRegistryEntity> trackingRepo, IAzureRepositoryService<ImportShipmentConfigurationEntity> shipmentRepo)
        {
            _config = config;
            _trackingRepository = trackingRepo;
            _importShipmentRepository = shipmentRepo;
        }
        [HttpGet]
        public async Task<IActionResult> TestDependencyInjected()
        {
            var ListTrackingRegistry = await _trackingRepository.GetAllAsync();
            var ListImportShipmentConfigs = await _importShipmentRepository.GetAllAsync();
            return Ok();
        }

        [HttpGet("OnFlyCreate")]
        public async Task<IActionResult> OnFlyCreate()
        {
            IAzureRepositoryService<TrackingRegistryEntity> tracking = new AzureRepositoryService<TrackingRegistryEntity>(_config, "trackingRegistry");
            IAzureRepositoryService<ImportShipmentConfigurationEntity> shipmentConfig = new AzureRepositoryService<ImportShipmentConfigurationEntity>(_config, "importShipmentConfiguration");
            var ListTrackingRegistry = await tracking.GetAllAsync();
            var ListImportShipmentConfigs = await shipmentConfig.GetAllAsync();
            return Ok();
        }
    }
}

