using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public  class User
    {
        DAL.User dalUser = new DAL.User();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="loginName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool Login(string loginName,string password)
        {
            MODEL.User model = dalUser.GetUserByName(loginName);
            return  model.Password.Equals(password)?true:false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="newPassword"></param>
        /// <returns></returns>
        public bool  ModifyPassword(string name, string newPassword)
        {
            return dalUser.ModifyPassword(name, newPassword) > 0;
        }
    }
}
