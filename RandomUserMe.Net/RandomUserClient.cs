using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using RandomUserMe.Net.Entities;

namespace RandomUserMe.Net
{
    public class RandomUserClient
    {
        private readonly HttpClient _client;

        public RandomUserClient()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("http://api.randomuser.me");
        }

        public async Task<RandomUser> GetRandomUserAsync(Gender gender)
        {
            var options = new GetUsersRequestOptions {Gender = gender};
            RandomUser user = await GetRandomUsersAsync(options).ContinueWith(t => t.Result.Single());

            return user;
        }

        public async Task<RandomUser> GetRandomUserAsync(string seed = null)
        {
            var options = new GetUsersRequestOptions {Seed = seed};
            RandomUser user = await GetRandomUsersAsync(options).ContinueWith(t => t.Result.Single());

            return user;
        }

        public Task<IEnumerable<RandomUser>> GetRandomUsersAsync(int count, Gender gender = Gender.Both)
        {
            var options = new GetUsersRequestOptions {Count = count, Gender = gender};
            return GetRandomUsersAsync(options);
        }

        private async Task<IEnumerable<RandomUser>> GetRandomUsersAsync(GetUsersRequestOptions options)
        {
            string uri = String.Format("/?{0}", options);

            HttpResponseMessage response = await _client.GetAsync(uri);
            response.EnsureSuccessStatusCode();

            IEnumerable<RandomUser> users = await response.Content.ReadAsAsync<GetUsersResponse>()
                .ContinueWith(t => t.Result.Results);

            return users;
        }
    }
}
