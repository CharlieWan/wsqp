using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Text;

namespace DAL
{
    public class Comment
    {
        #region 查询得到所有的评论数据
        /// <summary>
        /// 查询得到所有的评论数据
        /// </summary>
        /// <returns></returns>
        public List<MODEL.Comment> GetAllComments()
        {
            string sql = "select  *  from  comment where isdelete=0";
            List<MODEL.Comment> listCom = MySqlHelper.ExcuteList<MODEL.Comment>(sql);
            return listCom;
        }
        #endregion

        /// <summary>
        /// 插入数据到数据库
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddComment(MODEL.Comment model)
        {
            MySqlParameter[] par = { new MySqlParameter("@name",model.Vname),
                                   new MySqlParameter("@mobile",model.Mobilephone),
                                   new MySqlParameter("@email",model.Email),
                                   new MySqlParameter("@content",model.Ccontent),
                                   new MySqlParameter("@ip",model.Ipaddress),
                                   new MySqlParameter("@subject",model.Subject)
                                 };
            string sql = @"insert into comment(vname,mobilephone,email,ccontent,ipaddress,subject) values
                               (@name,@mobile,@email,@content,@ip,@subject);select @@identity";
            int res = MySqlHelper.ExcuteNonQuery(sql, par);
            return res;
        }
    }
}
