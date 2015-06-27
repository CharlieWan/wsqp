using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Text;

namespace DAL
{
    public class User
    {
        public MODEL.User GetUserByName(string loginName)
        {
            string sql = "select  *  from users where loginName=@name and isdelete=0";
            MySqlParameter sp = new MySqlParameter("@name", loginName);
            return MySqlHelper.ExcuteList<MODEL.User>(sql, sp)[0];
        }
    }
}
