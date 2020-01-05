using Tests.Models;

namespace Tests.Repositories
{
    public class UsersRepositoryMock : IUsersRepository
    {
        public User GetUserById(string id)
        {
            throw new System.NotImplementedException();
        }
    }
}