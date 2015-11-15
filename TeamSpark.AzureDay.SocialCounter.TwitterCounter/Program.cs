using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using TeamSpark.AzureDay.SocialCounter.TwitterCounter.Core;

namespace TeamSpark.AzureDay.SocialCounter.TwitterCounter
{
    // To learn more about Microsoft Azure WebJobs SDK, please see http://go.microsoft.com/fwlink/?LinkID=320976
    class Program
    {
        // Please set the following connection strings in app.config for this WebJob to run:
        // AzureWebJobsDashboard and AzureWebJobsStorage
        static void Main()
        {
            Twitter twitter = new Twitter();
            var data = twitter.GetTweets("#azureDay");

            foreach (var item in data.GroupBy(c=>c.user.name))
            {
                Console.WriteLine("User Name: {0}, count twwits {1}", item.Key, item.Count());
            }
            Console.ReadLine();
            //var host = new JobHost();
            //// The following code ensures that the WebJob will be running continuously
            //host.RunAndBlock();
        }
    }
}
