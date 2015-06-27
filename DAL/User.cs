using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Text;

namespace DAL
{
    public class User
    {
        /// <summary>
        /// 通过登录名查询到当前的用户实体
        /// </summary>
        /// <param name="loginName"></param>
        /// <returns></returns>
        public MODEL.User GetUserByName(string loginName)
        {
            string sql = "select  *  from users where loginName=@name and isdelete=0";
            MySqlParameter sp = new MySqlParameter("@name", loginName);
            return MySqlHelper.ExcuteList<MODEL.User>(sql, sp)[0];
        }

        /// <summary>
        /// 修改 用户密码
        /// </summary>
        /// <param name="name"></param>
        /// <param name="newPassword"></param>
        /// <returns></returns>
        public int ModifyPassword(string name, string newPassword)
        {
            string strSql = "update Users set password=@newP where loginName=@ln";
            MySqlParameter[] msp = { 
                                   new MySqlParameter("@newP",newPassword),
                                   new MySqlParameter("@ln",name)
                                   };
            return MySqlHelper.ExcuteNonQuery(strSql, msp);
        }
    }
}
