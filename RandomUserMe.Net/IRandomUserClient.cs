using System.Collections.Generic;
using System.Threading.Tasks;
using RandomUserMe.Net.Domain;

namespace RandomUserMe.Net
{
    public interface IRandomUserClient
    {
        Task<RandomUser> GetRandomUserAsync(Gender gender);
        Task<RandomUser> GetRandomUserAsync(string seed = null);
        Task<IEnumerable<RandomUser>> GetRandomUsersAsync(int count, Gender gender = Gender.Both);
    }
}