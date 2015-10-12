using NUnit.Framework;
using TeamSpark.AzureDay.SocialCounter.Shared.AzureStorage.Table.Entity;
using TeamSpark.AzureDay.SocialCounter.Shared.AzureStorage.Table.Enum;

namespace TeamSpark.AzureDay.SocialCounter.Test.Shared.AzureStorage.Table.Entity
{
    [TestFixture]
    public class SocialCount2016Test
    {
        [Test]
        public void SocialMediaSetTest()
        {
            var entity = new SocialCount2016();

            entity.SocialMedia = SocialMedia.Facebook;

            Assert.AreEqual(SocialMedia.Facebook.ToString(), entity.PartitionKey);
        }

        [Test]
        public void SocialMediaGetTest()
        {
            var entity = new SocialCount2016();

            entity.PartitionKey = SocialMedia.Facebook.ToString();

            Assert.AreEqual(SocialMedia.Facebook, entity.SocialMedia);
        }
    }
}
