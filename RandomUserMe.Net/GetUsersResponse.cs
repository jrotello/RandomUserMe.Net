using System.Collections.Generic;
using RandomUserMe.Net.Domain;

namespace RandomUserMe.Net
{
    public class GetUsersResponse
    {
        public IEnumerable<RandomUser> Results { get; set; }
    }
}
