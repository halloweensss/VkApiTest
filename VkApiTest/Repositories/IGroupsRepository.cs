using Tests.Models;

namespace Tests.Repositories
{
    public interface IGroupsRepository
    {
        Group GetGroupById(string id);
    }
}