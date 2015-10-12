using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;

namespace TeamSpark.AzureDay.SocialCounter.Shared.AzureStorage
{
    public abstract class AzureStorageBase
    {
        protected readonly CloudStorageAccount Account;

        protected AzureStorageBase()
        {
            Account = CloudStorageAccount.DevelopmentStorageAccount;
        }

        protected AzureStorageBase(string connectionString)
        {
            Account = CloudStorageAccount.Parse(connectionString);
        }

        protected AzureStorageBase(string name, string key, bool isHttps = true)
        {
            var credentials = new StorageCredentials(name, key);

            Account = new CloudStorageAccount(credentials, isHttps);
        }
    }
}