using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Text;

namespace DAL
{
    public class News
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cid"></param>
        /// <returns></returns>
        public List<MODEL.News> GetNewsBycid(int cid)
        {
            string sql = "select  *  from news inner join newsCat on news.catid=newsCat.id where news.isdelete=0 and news.catid=@cid order by ncreatedate desc";
            MySqlParameter sp = new MySqlParameter("@cid", cid);
            List<MODEL.News> list = new List<MODEL.News>();
            DataTable dt = MySqlHelper.ExcuteDataTable(sql, sp);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    MODEL.News model = new MODEL.News();
                    LoadEntityData(model, dr);
                    list.Add(model);
                }
            }
            return list;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddNews(MODEL.News model)
        {
            string sql = @"insert into news(ntitle,ncontent,catid,ncreatedate) values  (@ntitle,@ncontent,@catid,@ncd);select  @@identity";
            MySqlParameter[] sp = { 
                                new MySqlParameter("@ntitle",model.Ntitle),
                                new MySqlParameter("@ncontent",model.Ncontent),
                                new MySqlParameter("@catid",model.Catid),
                                new MySqlParameter("@ncd",DateTime.Now)
                               };
            return MySqlHelper.ExcuteNonQuery(sql, sp);
        }

        DAL.NewsCat dalCat = new DAL.NewsCat();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="?"></param>
        /// <param name="dr"></param>
        public void LoadEntityData(MODEL.News model, DataRow dr)
        {
            if (dr["id"] != null)
            {
                model.Id = Convert.ToInt32(dr["id"]);
            }
            if (dr["ntitle"] != null)
            {
                model.Ntitle = dr["ntitle"].ToString();
            }
            if (dr["ncontent"] != null)
            {
                model.Ncontent = dr["ncontent"].ToString();
            }
            if (dr["ncreatedate"] != null)
            {
                model.Ncreatedate = Convert.ToDateTime(dr["ncreatedate"]);
            }
            if (dr["isdelete"] != null)
            {
                model.Isdelete = Convert.ToBoolean(dr["isdelete"]);
            }
            if (dr["catid"] != null)
            {
                model.Catid = Convert.ToInt32(dr["catid"]);
            }
            if (dr["author"] != null)
            {
                model.Author = dr["author"].ToString();
            }
        }

        public DataTable GetAllNews()
        {
            string sql = "select  * from news where isdelete=0";
            return MySqlHelper.ExcuteDataTable(sql);
        }

        public int DelNews(int nid)
        {
            string sql = "update news set isdelete=1 where id=@nid";
            MySqlParameter sp = new MySqlParameter("@nid", nid);
            return MySqlHelper.ExcuteNonQuery(sql,sp);
        }

        public DataTable GetNewsById(int id)
        {
            string sql = "select  * from news where id=@id and isdelete=0";
            MySqlParameter par = new MySqlParameter("@id",id);
            return MySqlHelper.ExcuteDataTable(sql,par);
        }

        public int ModifyNews(MODEL.News model)
        {
            string sql = "update news set catid=@cid,ntitle=@title,ncontent=@content,ncreatedate=@ncd where id=@id";
            MySqlParameter[] par = { 
                                 new MySqlParameter("@cid",model.Catid),
                                 new MySqlParameter("@title",model.Ntitle),
                                 new MySqlParameter("@content",model.Ncontent),
                                 new MySqlParameter("@id",model.Id),
                                 new MySqlParameter("ncd",DateTime.Now)
                                 };
            return MySqlHelper.ExcuteNonQuery(sql, par);
        }

        public DataTable GetNewsCount()
        {
            string sql = "select  max(id),min(id) from News where isdelete=0";
            return MySqlHelper.ExcuteDataTable(sql);
        }

        public DataTable GetTop7()
        {
            string sql = "select *   from news where  isdelete=0   order by  ncreatedate   Desc limit 0,7";
            return MySqlHelper.ExcuteDataTable(sql);
        }

        public int GetNewsCountByCid(int cid)
        {
            string sql = "select  count(*) from News where isdelete=0 and news.catid=@cid";
            MySqlParameter par = new MySqlParameter("@cid",cid);
            DataTable dt= MySqlHelper.ExcuteDataTable(sql, par);
            return Convert.ToInt32(dt.Rows[0][0]);
        }
    }
}
