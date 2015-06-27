using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MODEL
{
    public class User
    {
        int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        string loginName;

        public string LoginName
        {
            get { return loginName; }
            set { loginName = value; }
        }
        string password;

        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        bool  isdelete;

        public bool Isdelete
        {
            get { return isdelete; }
            set { isdelete = value; }
        }
    }
}
