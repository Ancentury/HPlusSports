using HPlusSportsAPI.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Azure.Cosmos.Table;
using Microsoft.Azure.Cosmos.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HPlusSportsAPI.Services
{
    /// <summary>
    /// Manages reading order history from table storage
    /// </summary>
    public class AzureTableService : ITableService
    {
        IConfiguration config;
        string tableName, partitionName;

        public AzureTableService(IConfiguration configuration)
        {
            config = configuration;
            tableName = config[Constants.KEY_TABLE];
            partitionName = config[Constants.KEY_TABLE_PARTITION];
        }

        public async Task<List<OrderHistoryItem>> GetOrderHistoryAsync()
        {
            CloudStorageAccount acct = CloudStorageAccount.Parse(config[Constants.KEY_STORAGE_CNN]);

            var tableClient = acct.CreateCloudTableClient();

            var table = tableClient.GetTableReference(tableName);

            await table.CreateIfNotExistsAsync();

            var historyQuery = new TableQuery<Models.OrderHistoryItem>().Where(
                TableQuery.GenerateFilterCondition("PartitionKey",
                QueryComparisons.Equal, partitionName));

            TableContinuationToken queryToken = null;

            var tableItems = await table.ExecuteQuerySegmentedAsync<Models.OrderHistoryItem>(historyQuery, queryToken);
            
            return tableItems.ToList();
        }
    }
}
