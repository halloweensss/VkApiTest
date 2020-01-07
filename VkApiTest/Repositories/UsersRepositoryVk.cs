using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Tests.Models;
using Tests.WebClient;

namespace Tests.Repositories
{
    public class UsersRepositoryVk: IUsersRepository
    {

        private string accessToken =
            "e4dd7cea02356d1d975085be3d5234a260f2f5a32e3aac8084cc742583532728668a7850edc8d0afc1495";

        private string url = "https://api.vk.com/method/";
        
        public User GetUserById(string id)
        {
            string request = $"{url}users.get?user_ids={id}&access_token={accessToken}&v=5.103";
            WebHelper webHelper = new WebHelper();
            string json = webHelper.SendRequest(request, "GET");
            return Parse(json);
        }

        private User Parse(string json)
        {
            JObject userJObject = JObject.Parse(json);
            JToken userInfo = userJObject["response"][0];
            User user = new User();
            user.Id = userInfo["id"].ToString();
            user.FirstName = userInfo["first_name"].ToString();
            user.LastName = userInfo["last_name"].ToString();
            user.IsClosed = (bool)userInfo["is_closed"];
            return user;
        }
    }
}