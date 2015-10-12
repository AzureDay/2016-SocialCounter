using System;
using Microsoft.WindowsAzure.Storage.Table;
using TeamSpark.AzureDay.SocialCounter.Shared.AzureStorage.Table.Enum;

namespace TeamSpark.AzureDay.SocialCounter.Shared.AzureStorage.Table.Entity
{
    public sealed class SocialCount2016Run : TableEntity
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
        public DateTime LastRun
        {
            get
            {
                return new DateTime(DateTime.MaxValue.Ticks - new DateTime(long.Parse(RowKey)).Ticks);
            }
            set
            {
                RowKey = (DateTime.MaxValue.Ticks - value.Ticks).ToString();
            }
        }
    }
}
