using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.WindowsAzure.Storage.Table;

namespace TeamSpark.AzureDay.SocialCounter.Shared.AzureStorage.Table
{
    public abstract class AzureTableStorageBase<T> : AzureStorageBase where T : TableEntity, new()
    {
        public static readonly string DefaultPartitionKey = string.Empty;

        protected CloudTableClient Client { get; private set; }

        protected CloudTable Table { get; private set; }

        protected abstract string TableName { get; }

		#region constructors

        protected AzureTableStorageBase()
			: base()
        {
            InitilizeInternal();
        }

        protected AzureTableStorageBase(string connectionString)
            : base(connectionString)
        {
            InitilizeInternal();
        }

        protected AzureTableStorageBase(string name, string key, bool isHttps = true)
            : base(name, key, isHttps)
        {
            InitilizeInternal();
        }

		#endregion

        private void InitilizeInternal()
        {
            Client = Account.CreateCloudTableClient();

            Table = Client.GetTableReference(TableName);
        }

		public void CreateTableIfNotExists()
		{
			Table.CreateIfNotExists();
		}

		#region queries

		protected IList<T> GetEntitiesByFilter(IList<KeyValuePair<string, object>> filters, IList<string> columns = null, int? rowsLimit = null)
		{
			if (filters != null && filters.Count > 0)
			{
				var filterString = GenerateFilterCondition(filters[0].Key, filters[0].Value);

				for (int i = 1; i < filters.Count; i++)
				{
					var filterNew = GenerateFilterCondition(filters[i].Key, filters[i].Value);

					filterString = TableQuery.CombineFilters(filterString, TableOperators.And, filterNew);
				}

				return GetEntitiesByFilter(filterString, columns, rowsLimit);
			}

			return GetEntitiesByFilter(string.Empty, columns, rowsLimit);
		}

		protected IList<T> GetEntitiesByFilter(string filters, IList<string> columns = null, int? rowsLimit = null)
		{
			var query = new TableQuery<T>();

			if (!string.IsNullOrEmpty(filters))
			{
				query = query.Where(filters);
			}

			if (columns != null && columns.Any())
			{
				query = query.Select(columns);
			}

			if (rowsLimit.HasValue)
			{
				query = query.Take(rowsLimit.Value);
			}

			return Table.ExecuteQuery(query).ToList();
		}

		protected T GetEntityByKey(string partitionKey, string rowKey)
		{
			var operation = TableOperation.Retrieve<T>(partitionKey, rowKey);

			var result = (T)Table.Execute(operation).Result;

		    return result;
		}

		private string GenerateFilterCondition(string key, object value)
		{
			if (value is string)
			{
				return TableQuery.GenerateFilterCondition(key, QueryComparisons.Equal, (string)value);
			}

			if (value is Guid)
			{
				return TableQuery.GenerateFilterConditionForGuid(key, QueryComparisons.Equal, (Guid)value);
			}

			if (value is byte || value is short || value is int)
			{
				return TableQuery.GenerateFilterConditionForInt(key, QueryComparisons.Equal, (int)value);
			}

			if (value is long)
			{
				return TableQuery.GenerateFilterConditionForLong(key, QueryComparisons.Equal, (long)value);
			}

			if (value is bool)
            {
				return TableQuery.GenerateFilterConditionForBool(key, QueryComparisons.Equal, (bool)value);
            }

			if (value is DateTimeOffset)
			{
				return TableQuery.GenerateFilterConditionForDate(key, QueryComparisons.Equal, (DateTimeOffset)value);
			}

			if (value is DateTime)
			{
				return TableQuery.GenerateFilterConditionForDate(key, QueryComparisons.Equal, new DateTimeOffset((DateTime)value));
			}

			if (value is float || value is double)
			{
				return TableQuery.GenerateFilterConditionForDouble(key, QueryComparisons.Equal, (double)value);
			}

			throw new NotSupportedException();
		}

		#endregion

		#region commands

	    protected void DeleteEntityByKey(string partitionKey, string rowKey)
	    {
			var retrieveOperation = TableOperation.Retrieve<T>(partitionKey, rowKey);

			var retrievedResult = (T)Table.Execute(retrieveOperation).Result;

            retrievedResult.ETag = "*";

			var operation = TableOperation.Delete(retrievedResult);

			Table.Execute(operation);
		}

		public T InsertEntity(T entity)
		{
			var operation = TableOperation.Insert(entity);

			var result = (T)Table.Execute(operation).Result;

		    return result;
		}

		public T UpdateEntity(T entity)
		{
            entity.ETag = "*";

            var operation = TableOperation.Replace(entity);

			var result = (T)Table.Execute(operation).Result;

		    return result;
		}

		#endregion
	}
}