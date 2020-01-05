using MockServer;
using NUnit.Framework;
using Tests.Models;
using Tests.Repositories;
using Tests.Services;

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
            //Server server = new Server();
            //server.Start();
            
            
            IUsersRepository userRepository = new UsersRepositoryMock();
            UsersService usersService = new UsersService(userRepository);
            
            User user = usersService.GetUserById("70199826");
            
            Assert.AreEqual("Антон", user.FirstName);
            Assert.AreEqual("Колодяжный",user.LastName);
            
            //server.Stop();
            
            userRepository = new UsersRepositoryVk();
            usersService = new UsersService(userRepository);
            user = usersService.GetUserById("70199826");
            
            Assert.AreEqual("Антон", user.FirstName);
            Assert.AreEqual("Колодяжный",user.LastName);
            
        }

        [Test]
        public void GetGroupById()
        {
            IGroupsRepository groupRepository = new GroupsRepositoryVk();
            GroupsService groupsService = new GroupsService(groupRepository);
            
            Group group = groupsService.GetGroupById("1");
            
            Assert.AreEqual("ВКонтакте API", group.Name);
            
            groupRepository = new GroupsRepositoryMock();
            groupsService = new GroupsService(groupRepository);
            
            group = groupsService.GetGroupById("1");
            
            Assert.AreEqual("ВКонтакте API", group.Name);
        }
    }
}