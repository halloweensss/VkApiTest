using MockServer;
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
            Server server = new Server();
            server.Start();
            
            IUsersRepository userRepository = new UsersRepositoryMock();
            User user = userRepository.GetUserById("70199826");
            
            Assert.AreEqual("Антон", user.FirstName);
            Assert.AreEqual("Колодяжный",user.LastName);
            
            server.Stop();
            
            userRepository = new UsersRepositoryVk();
            user = userRepository.GetUserById("70199826");
            
            Assert.AreEqual("Антон", user.FirstName);
            Assert.AreEqual("Колодяжный",user.LastName);

        }
    }
}