using AzureRepository.Common.Azure.Entity;
using AzureRepository.Common.Azure.StorageAccount;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AzureRepository.Common.Azure.ServiceBase
{
    public class AzureRepositoryService<T> : IAzureRepositoryService<T> where T : AzureEntityBase, new()
    {
        private static CloudTable _table = null;
        public AzureAccountSettings _conn;
        private static IConfiguration _config;
        public AzureRepositoryService(IConfiguration config, string table)
        {
            _config = config;
            Initalize(table);
        }
        private void Initalize(string table)
        {
            _conn = new AzureAccountSettings(_config, table);
            new Action(async () => await CreateTableAsync())();
        }
        public async Task<List<T>> GetAllAsync()
        {
            List<T> results = new List<T>();
            TableContinuationToken continuationToken = null;
            do
            {
                TableQuerySegment<T> queryResults = await _table.ExecuteQuerySegmentedAsync(new TableQuery<T>(), continuationToken);
                continuationToken = queryResults.ContinuationToken;
                results.AddRange(queryResults.Results);
            } while (continuationToken != null);
            return results;
        }
        public async Task<T> GetAsync(string partition, string row)
        {
            return (T)(dynamic) await _table.ExecuteAsync(TableOperation.Retrieve<T>(partition, row));
        }
        public async Task InsertAsync(T record)
        {
            await _table.ExecuteAsync(TableOperation.Insert(record));
        }
        public async Task MergeAsync(T record)
        {
            await _table.ExecuteAsync(TableOperation.InsertOrMerge(record));
        }
        public async Task UpdateAsync(T record)
        {
            await _table.ExecuteAsync(TableOperation.InsertOrReplace(record));
        }
        public async Task DeleteAsync(string partition, string row)
        {
            await _table.ExecuteAsync(TableOperation.Delete(await GetAsync(partition, row)));
        }
        public async Task CreateTableAsync()
        {
            if (_table == null)
            {
                _table = CloudStorageAccount.Parse(_conn.Account).CreateCloudTableClient().GetTableReference(_conn.Table);
                await _table.CreateIfNotExistsAsync();
            }
        }
    }
}
