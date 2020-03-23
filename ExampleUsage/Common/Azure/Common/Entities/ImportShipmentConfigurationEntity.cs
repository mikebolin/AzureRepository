using AzureRepository.Common.Azure.Entity;
using System;

namespace AzureRepository.Common.Azure.Common.Entities
{
    public class ImportShipmentConfigurationEntity : AzureEntityBase
    {
        public string APIPassword { get; set; }
        public string APIUser { get; set; }
        public string AdapterType { get; set; }
        public string BookRequestPath { get; set; }
        public string BookResponsePath { get; set; }
        public bool CanProcess { get; set; }
        public string ErrorEmail { get; set; }
        public string ErrorPath { get; set; }
        public string Host { get; set; }
        public DateTime? LastFileProcessed { get; set; }
        public DateTime? LastRun { get; set; }
        public string Password { get; set; }
        public int Port { get; set; }
        public bool SendResponse { get; set; }
        public string UserName { get; set; }
        public string Environment { get; set; }

    }
}
