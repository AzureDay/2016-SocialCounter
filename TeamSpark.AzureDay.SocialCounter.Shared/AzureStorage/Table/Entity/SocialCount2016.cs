using Microsoft.WindowsAzure.Storage.Table;
using TeamSpark.AzureDay.SocialCounter.Shared.AzureStorage.Table.Enum;

namespace TeamSpark.AzureDay.SocialCounter.Shared.AzureStorage.Table.Entity
{
    public sealed class SocialCount2016 : TableEntity
    {
        [IgnoreProperty]
        public SocialMedia SocialMedia
        {
            get
            {
                return (SocialMedia)System.Enum.Parse(typeof(SocialMedia), PartitionKey);
            }
            set
            {
                PartitionKey = value.ToString();
            }
        }

        [IgnoreProperty]
        public string UserId
        {
            get { return RowKey; }
            set { RowKey = value; }
        }

        public int PostsCount { get; set; }
    }
}
