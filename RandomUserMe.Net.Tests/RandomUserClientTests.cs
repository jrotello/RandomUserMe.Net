using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using RandomUserMe.Net.Domain;

namespace RandomUserMe.Net.Tests
{
    [TestFixture]
    public class RandomUserClientTests
    {
        private IRandomUserClient _client;

        [SetUp]
        public void Setup()
        {
            _client = new RandomUserClient();
        }

        [TearDown]
        public void TearDown()
        {
            _client = null;
        }


        [TestCase(0, 1)]
        [TestCase(1, 1)]
        [TestCase(20, 20)]
        public async void GetRandomUsers_ReturnsCorrectNumberOfUsers(int count, int expected)
        {
            IEnumerable<RandomUser> users = await _client.GetRandomUsersAsync(count);

            Assert.AreEqual(expected, users.Count());
        }

        [TestCase(Gender.Male)]
        [TestCase(Gender.Female)]
        public async void GetRandomUsers_ReturnsSpecificGender(Gender gender)
        {
            IEnumerable<RandomUser> users = await _client.GetRandomUsersAsync(20, gender);

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
            RandomUser randomUser = await _client.GetRandomUserAsync("JasonR");

            Assert.AreEqual("isaac", randomUser.User.Name.First);
            Assert.AreEqual("stewart", randomUser.User.Name.Last);
        }

        [TestCase(Gender.Male)]
        [TestCase(Gender.Female)]
        public async void GetRandomUserAsync_WithGender(Gender gender)
        {
            RandomUser randomUser = await _client.GetRandomUserAsync(gender);

            Assert.AreEqual(gender, randomUser.User.Gender);
        }
    }
}
