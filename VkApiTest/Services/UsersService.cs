using Tests.Models;
using Tests.Repositories;

namespace Tests.Services
{
    public class UsersService
    {
        private IUsersRepository _usersRepository;

        public UsersService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public User GetUserById(string id)
        {
            return _usersRepository.GetUserById(id);
        }
    }
}