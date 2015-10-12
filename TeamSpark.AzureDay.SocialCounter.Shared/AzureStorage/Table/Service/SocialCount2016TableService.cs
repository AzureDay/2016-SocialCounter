using TeamSpark.AzureDay.SocialCounter.Shared.AzureStorage.Table.Entity;
using TeamSpark.AzureDay.SocialCounter.Shared.AzureStorage.Table.Enum;

namespace TeamSpark.AzureDay.SocialCounter.Shared.AzureStorage.Table.Service
{
    public sealed class SocialCount2016TableService : AzureTableStorageBase<SocialCount2016>
    {
        protected override string TableName
        {
            get { return "SocialCount2016"; }
        }

        public SocialCount2016 GetByKeys(SocialMedia socialMedia, string userId)
        {
            var entity = new SocialCount2016
            {
                SocialMedia = socialMedia,
                UserId = userId
            };

            return GetEntityByKey(entity.PartitionKey, entity.RowKey);
        }

        public void DeleteByKeys(SocialMedia socialMedia, string userId)
        {
            var entity = new SocialCount2016
            {
                SocialMedia = socialMedia,
                UserId = userId
            };

            DeleteEntityByKey(entity.PartitionKey, entity.RowKey);
        }
    }
}
