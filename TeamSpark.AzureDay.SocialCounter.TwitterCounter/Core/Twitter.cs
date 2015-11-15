using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using Newtonsoft.Json;
using TeamSpark.AzureDay.SocialCounter.TwitterCounter.Model;

namespace TeamSpark.AzureDay.SocialCounter.TwitterCounter.Core
{
    public class Twitter
    {
        public List<Status> GetTweets(string twitterHashTag)
        {

            List<Status> lstTweets = new List<Status>();

            // New Code added for Twitter API 1.1
            if (!string.IsNullOrEmpty(twitterHashTag))
            {
                var twitter = new TwitterHelper(ConfigurationManager.AppSettings["OauthConsumerKey"],
                                                ConfigurationManager.AppSettings["OauthConsumerKeySecret"],
                                                ConfigurationManager.AppSettings["OauthAccessToken"],
                                                ConfigurationManager.AppSettings["OauthAccessTokenSecret"]);

                var response = twitter.GetTweets(twitterHashTag, 100);

                var timeline = JsonConvert.DeserializeObject<TwitterModel>(response);

                lstTweets.AddRange(timeline.statuses);
            }
            return lstTweets;
        }
    }
}