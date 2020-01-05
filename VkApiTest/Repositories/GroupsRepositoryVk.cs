using Newtonsoft.Json.Linq;
using Tests.Models;
using Tests.WebClient;

namespace Tests.Repositories
{
    public class GroupsRepositoryVk: IGroupsRepository
    {
        private string accessToken =
            "e4dd7cea02356d1d975085be3d5234a260f2f5a32e3aac8084cc742583532728668a7850edc8d0afc1495";

        private string url = "https://api.vk.com/method/";
        
        public Group GetGroupById(string id)
        {
            string request = $"{url}groups.getById?group_id={id}&access_token={accessToken}&v=5.103";
            WebHelper webHelper = new WebHelper();
            string json = webHelper.SendRequest(request, "GET");
            return Parse(json);
        }
        
        private Group Parse(string json)
        {
            JObject groupJObject = JObject.Parse(json);
            JToken groupInfo = groupJObject["response"][0];
            Group group = new Group();
            group.Id = groupInfo["id"].ToString();
            group.Name = groupInfo["name"].ToString();
            return group;
        }
    }
}