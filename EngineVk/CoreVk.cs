using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VkNet;
using VkNet.Enums.Filters;

namespace EngineVk
{
    public class CoreVk:IDisposable
    {
        private const int APP_ID = 5417317;
        private VkApi vk;
        public bool authorize { private set; get; }

        public CoreVk()
        {
        }

        public VkApi Init(string login, string pass)
        {

            vk = new VkApi();
            Settings scope = Settings.All;
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


        public UserVk getUsers(long Userid)
        {
            var info = vk.Users.Get(Userid);
            return new UserVk(info);
        }

        public List<UserVk> getUsers(long[] Userid)
        {
            var info = vk.Users.Get(Userid);
            List<UserVk> users = new List<UserVk>();
            foreach (var user in info)
            {
                users.Add(new UserVk(user));
            }
            return users;
        }

        //public UserVk getUsers(long Userid, ProfileFields profileFiled)
        //{
        //    var info = vk.Users.Get(Userid,profileFiled);
        //    var ss = info.Counters.Audios;
        //    return new UserVk(info);
        //} TODO search information for gets request users info

        //public void getAudio(long userId)
        //{
        //    VkNet.Model.User user;
        //    var audios = vk.Audio.Get(userId, out user, null, null, 3, 5);
        //    //var ids = vk.Audio.Get(userId,out user).Select(x => x.Id).ToList();
        //    var t = audios;
        //}TODO audio


        public void getDialog()
        {
            int totalCount=0;
            int unreadCount=0;
            var t = vk.Messages.GetDialogs(out totalCount,out unreadCount,10,0,false,0,0);
        }

        public void getMessage()
        {
            VkNet.Model.RequestParams.MessagesGetParams paramss = new VkNet.Model.RequestParams.MessagesGetParams();
            paramss.Count = 20;
            paramss.Filters = VkNet.Enums.MessagesFilter.All;
            int gfgf=100;
            System.TimeSpan re = default(System.TimeSpan);
            var r = vk.Messages.Get(VkNet.Enums.MessageType.Sended,out gfgf,200,0,null,VkNet.Enums.MessagesFilter.All,10);
            foreach (var fd in r) {
                var g=fd.Body;
                var t = fd.ActionText;
            }
        }


        public long sendMessage(UserVk user,string message)
        {
            VkNet.Model.RequestParams.MessagesSendParams settings = new VkNet.Model.RequestParams.MessagesSendParams()
                                                                        { UserId=user.UID, Message= message};

           return vk.Messages.Send(settings);

        }

        public void Dispose()
        {
            vk = null;
        }



    }
}


