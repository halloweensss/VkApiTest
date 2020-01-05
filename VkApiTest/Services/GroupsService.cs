using Tests.Models;
using Tests.Repositories;

namespace Tests.Services
{
    public class GroupsService
    {
        private IGroupsRepository _groupsRepository;

        public GroupsService(IGroupsRepository groupsRepository)
        {
            _groupsRepository = groupsRepository;
        }

        public Group GetGroupById(string id)
        {
            return _groupsRepository.GetGroupById(id);
        }
    }
}