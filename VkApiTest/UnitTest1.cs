using NUnit.Framework;
using Tests.Models;
using Tests.Repositories;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        
        }

        [Test]
        public void GetUserById()
        {
            IUsersRepository userRepository = new UsersRepositoryVk();
            User user = userRepository.GetUserById("70199826");
            
            Assert.AreEqual("Антон", user.FirstName);
            Assert.AreEqual("Колодяжный",user.LastName);
            
        }
    }
}