using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMSclient
{
    class UserInfo
    {
        private static string user;
        private static string power;
        public static string UserID
        {
            get
            {
                return user;
            }
            set
            {
                user = value;
            }
        }
        public static string UserPower
        {
            get
            {
                return power;
            }
            set
            {
                power = value;
            }
        }
    }
}
