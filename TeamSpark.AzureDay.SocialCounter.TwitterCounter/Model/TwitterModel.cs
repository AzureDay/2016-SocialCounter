using System;
using System.Collections.Generic;

namespace TeamSpark.AzureDay.SocialCounter.TwitterCounter.Model
{
    public class TwitterModel
    {
        public List<Status> statuses
        { get; set; }
    }

    public class User
    {
        public long id { get; set; }
        public string id_str { get; set; }
        public string name { get; set; }
        public string screen_name { get; set; }
        public string location { get; set; }
        public string lang { get; set; }
    }

    public class Status
    {
        public string created_at { get; set; }
        public long id { get; set; }
        public string id_str { get; set; }
        public string text { get; set; }
        public string source { get; set; }
        public User user { get; set; }
        public string lang { get; set; }
    }

}