using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public  class User
    {
        DAL.User dalUser = new DAL.User();
        public bool Login(string loginName,string password)
        {
            MODEL.User model = dalUser.GetUserByName(loginName);
            return  model.Password.Equals(password)?true:false;
        }
    }
}
