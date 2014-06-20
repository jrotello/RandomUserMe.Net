using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using RandomUserMe.Net.Converters;

namespace RandomUserMe.Net.Entities
{
    public class User
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public Gender Gender { get; set; }
        public Name Name { get; set; }
        public Location Location { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public string Md5 { get; set; }
        public string Sha1 { get; set; }
        public string Sha256 { get; set; }
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime Registered { get; set; }
        [JsonProperty("dob")]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime BirthDate { get; set; }
        public string Phone { get; set; }
        public string Cell { get; set; }
        public string SSN { get; set; }
        [JsonConverter(typeof(UriConverter))]
        public Uri Picture { get; set; }
    }
}
