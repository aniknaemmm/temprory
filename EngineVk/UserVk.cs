using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VkNet.Model;

namespace EngineVk
{
    public class UserVk
    {
        private long Uid;
        private string firstName;
        private string lastName;

        public long UID
        {
             get { return Uid; }
        }

        public UserVk(long Uid, string firstName, string lastName)
        {
            this.Uid = Uid;
            this.firstName = firstName;
            this.lastName = lastName;
        }


        public UserVk(User User) : this(User.Id, User.FirstName, User.LastName)
        {
        }


        public override string ToString()
        {
            return String.Format("{0} {1} - {2}",lastName,firstName, Uid);
        }
    }
}
