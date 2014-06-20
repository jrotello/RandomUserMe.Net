using System.Collections.Generic;
using RandomUserMe.Net.Entities;

namespace RandomUserMe.Net
{
    public class GetUsersResponse
    {
        public IEnumerable<RandomUser> Results { get; set; }
    }
}
