using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using RandomUserMe.Net.Entities;

namespace RandomUserMe.Net.Tests
{
    [TestFixture]
    public class RandomUserClientTests
    {
        [TestCase(0, 1)]
        [TestCase(1, 1)]
        [TestCase(20, 20)]
        public async void GetRandomUsers_ReturnsCorrectNumberOfUsers(int count, int expected)
        {
            var client = new RandomUserClient();
            IEnumerable<RandomUser> users = await client.GetRandomUsersAsync(count);

            Assert.AreEqual(expected, users.Count());
        }

        [TestCase(Gender.Male)]
        [TestCase(Gender.Female)]
        public async void GetRandomUsers_ReturnsSpecificGender(Gender gender)
        {
            var client = new RandomUserClient();
            IEnumerable<RandomUser> users = await client.GetRandomUsersAsync(20, gender);

            var genders = users.Select(u => u.User.Gender).Distinct().ToList();
            Assert.AreEqual(1, genders.Count);
            Assert.AreEqual(gender, genders.Single());
        }

        [Test]
        public async void GetRandomUserAsync()
        {
            var client = new RandomUserClient();
            RandomUser randomUser = await client.GetRandomUserAsync();

            Assert.IsNotNull(randomUser);
        }

        [Test]
        public async void GetRandomUserAsync_WithSeed()
        {
            var client = new RandomUserClient();
            RandomUser randomUser = await client.GetRandomUserAsync("JasonR");

            Assert.AreEqual("isaac", randomUser.User.Name.First);
            Assert.AreEqual("stewart", randomUser.User.Name.Last);
        }

        [TestCase(Gender.Male)]
        [TestCase(Gender.Female)]
        public async void GetRandomUserAsync_WithGender(Gender gender)
        {
            var client = new RandomUserClient();
            RandomUser randomUser = await client.GetRandomUserAsync(gender);

            Assert.AreEqual(gender, randomUser.User.Gender);
        }
    }
}
