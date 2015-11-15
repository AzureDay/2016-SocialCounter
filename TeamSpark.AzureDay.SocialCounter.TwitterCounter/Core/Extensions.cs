using System;
using System.Collections.Generic;
using System.Text;

namespace TeamSpark.AzureDay.SocialCounter.TwitterCounter.Core
{
    public static class Extensions
    {
        public static string ToWebString(this SortedDictionary<string, string> source)
        {
            var body = new StringBuilder();
            foreach (var requestParameter in source)
            {
                body.Append(requestParameter.Key);

                body.Append("=");

                body.Append(Uri.EscapeDataString(requestParameter.Value));

                body.Append("&");
            } 

            body.Remove(body.Length - 1, 1); return body.ToString();
        }
    }
}