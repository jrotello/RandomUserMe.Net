using System;
using Newtonsoft.Json;
using RandomUserMe.Net.Converters;

namespace RandomUserMe.Net.Domain
{
    public class UserPictureInfo
    {
        [JsonConverter(typeof(UriConverter))]
        public Uri Large { get; set; }
        [JsonConverter(typeof(UriConverter))]
        public Uri Medium { get; set; }
        [JsonConverter(typeof(UriConverter))]
        public Uri Thumbnail { get; set; }
    }
}