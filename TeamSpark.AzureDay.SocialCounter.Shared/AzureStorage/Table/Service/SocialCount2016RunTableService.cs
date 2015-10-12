using System;
using System.Collections.Generic;
using System.Linq;
using TeamSpark.AzureDay.SocialCounter.Shared.AzureStorage.Table.Entity;
using TeamSpark.AzureDay.SocialCounter.Shared.AzureStorage.Table.Enum;

namespace TeamSpark.AzureDay.SocialCounter.Shared.AzureStorage.Table.Service
{
    public sealed class SocialCount2016RunTableService : AzureTableStorageBase<SocialCount2016Run>
    {
        protected override string TableName
        {
            get { return "SocialCount2016Run"; }
        }

        public SocialCount2016Run GetByKeys(SocialMedia socialMedia, DateTime lastRun)
        {
            var entity = new SocialCount2016Run
            {
                SocialMedia = socialMedia,
                LastRun = lastRun
            };

            return GetEntityByKey(entity.PartitionKey, entity.RowKey);
        }

        public void DeleteByKeys(SocialMedia socialMedia, DateTime lastRun)
        {
            var entity = new SocialCount2016Run
            {
                SocialMedia = socialMedia,
                LastRun = lastRun
            };

            DeleteEntityByKey(entity.PartitionKey, entity.RowKey);
        }

        public SocialCount2016Run GetLastRun(SocialMedia socialMedia)
        {
            var entity = new SocialCount2016Run
            {
                SocialMedia = socialMedia
            };

            var condition = new List<KeyValuePair<string, object>>();
            condition.Add(new KeyValuePair<string, object>("PartitionKey", entity.PartitionKey));

            return GetEntitiesByFilter(condition, rowsLimit: 1).FirstOrDefault();
        }
    }
}
