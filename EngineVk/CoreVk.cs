using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VkNet;
using VkNet.Enums.Filters;

namespace EngineVk
{
    public class CoreVk
    {
        private const int APP_ID = 5417317;
        public bool authorize { private set; get; }

        public CoreVk()
        {
        }

        public VkApi Init(string login, string pass)
        {

            var vk = new VkApi();
            Settings scope = Settings.Friends;
            vk.Authorize(new ApiAuthParams
            {
                ApplicationId = APP_ID,
                Login = login,
                Password = pass,
                Settings = scope
            });
            authorize = vk.IsAuthorized;
            return vk;

        }

    }
}


