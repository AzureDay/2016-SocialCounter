using System;
using NUnit.Framework;
using TeamSpark.AzureDay.SocialCounter.Shared.AzureStorage.Table.Entity;
using TeamSpark.AzureDay.SocialCounter.Shared.AzureStorage.Table.Enum;

namespace TeamSpark.AzureDay.SocialCounter.Test.Shared.AzureStorage.Table.Entity
{
    [TestFixture]
    public class SocialCount2016RunTest
    {
        [Test]
        public void SocialMediaSetTest()
        {
            var entity = new SocialCount2016Run();

            entity.SocialMedia = SocialMedia.Facebook;

            Assert.AreEqual(SocialMedia.Facebook.ToString(), entity.PartitionKey);
        }

        [Test]
        public void SocialMediaGetTest()
        {
            var entity = new SocialCount2016Run();

            entity.PartitionKey = SocialMedia.Facebook.ToString();

            Assert.AreEqual(SocialMedia.Facebook, entity.SocialMedia);
        }

        [Test]
        public void LastRunSetTest()
        {
            var entity = new SocialCount2016Run();

            var date = new DateTime(2000, 1, 20, 11, 25, 42);
            entity.LastRun = date;

            Assert.AreEqual((DateTime.MaxValue.Ticks - date.Ticks).ToString(), entity.RowKey);
        }

        [Test]
        public void LastRunGetTest()
        {
            var entity = new SocialCount2016Run();

            var date = new DateTime(2000, 1, 20, 11, 25, 42);
            entity.RowKey = (DateTime.MaxValue.Ticks - date.Ticks).ToString();

            Assert.AreEqual(date, entity.LastRun);
        }

        [Test]
        public void RowKeyOrderTest()
        {
            var entity1 = new SocialCount2016Run();
            var entity2 = new SocialCount2016Run();

            entity1.LastRun = new DateTime(2000, 1, 2);
            entity2.LastRun = new DateTime(2000, 10, 20);

            Assert.IsTrue(long.Parse(entity1.RowKey) > long.Parse(entity2.RowKey));
        }
    }
}
