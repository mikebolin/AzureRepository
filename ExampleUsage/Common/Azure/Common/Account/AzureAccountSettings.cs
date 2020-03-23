using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace AzureRepository.Common.Azure.StorageAccount
{
    public class AzureAccountSettings
    {
        public string Account { get; set; }
        public string Table { get; set; }

        public IConfiguration _config;
        public AzureAccountSettings(IConfiguration config, string table) 
        {
            _config = config;
            var storageAccount = _config.GetSection("AppSettings:AzureStorage:Accounts:BlueshipRM:StorageAccount").Value;
            if (string.IsNullOrEmpty(storageAccount)) throw new ArgumentNullException("storageAccount");
            if (string.IsNullOrEmpty(table)) throw new ArgumentNullException("table");
            this.Account = storageAccount;
            this.Table = table;
        }
    }
}
