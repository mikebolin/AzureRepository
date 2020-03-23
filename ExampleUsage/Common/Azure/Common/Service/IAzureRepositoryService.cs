using AzureRepository.Common.Azure.Entity;
using AzureRepository.Common.Azure.StorageAccount;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AzureRepository.Common.Azure.ServiceBase
{
    public interface IAzureRepositoryService<T> where T : AzureEntityBase, new()
    {
        Task CreateTableAsync();
        Task<List<T>> GetAllAsync();
        Task<T> GetAsync(string partitionKey, string rowKey);
        Task InsertAsync(T item);
        Task MergeAsync(T item);
        Task UpdateAsync(T item);
        Task DeleteAsync(string partitionKey, string rowKey);
    }
}
