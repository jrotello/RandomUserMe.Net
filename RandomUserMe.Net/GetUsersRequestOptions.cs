using System;
using System.Collections.Generic;
using System.Linq;
using RandomUserMe.Net.Domain;

namespace RandomUserMe.Net
{
    public class GetUsersRequestOptions
    {
        public int Count { get; set; }
        public Gender Gender { get; set; }
        public string Seed { get; set; }

        public override string ToString()
        {
            var parameters = new Dictionary<string, string>();

            if (Count > 1)
            {
                parameters.Add("results", Count.ToString());
            }

            if (Gender != Gender.Both)
            {
                parameters.Add("gender", Gender.ToString().ToLower());
            }

            if (!String.IsNullOrEmpty(Seed))
            {
                parameters.Add("seed", Seed);
            }

            string result = String.Join("&", parameters.Select(p => String.Format("{0}={1}", p.Key, p.Value)));

            return result;
        }
    }
}