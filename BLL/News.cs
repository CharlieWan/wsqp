using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BLL
{
    public class News
    {
        DAL.News dal = new DAL.News();
        public List<MODEL.News> GetAllNews(int cid)
        {
            return dal.GetNewsBycid(cid);
        }

        public bool AddNews(MODEL.News model)
        {
            return dal.AddNews(model) > 0 ? true : false;
        }

        public DataTable GetAllNews()
        {
            return dal.GetAllNews();
        }

        public bool DelNews(int nid)
        {
            return dal.DelNews(nid) > 0 ? true : false;
        }

        public DataTable GetNewsById(int id)
        {
            return dal.GetNewsById(id);
        }

        public int ModifyNews(MODEL.News model)
        {
            return dal.ModifyNews(model);
        }

        public DataTable  GetNewsCount()
        {
            return dal.GetNewsCount();
        }

        public DataTable GetTop7()
        {
            return dal.GetTop7();
        }


        public int GetNewsCountByCid(int cid)
        {
            return dal.GetNewsCountByCid(cid);
        }

        public List<MODEL.News> GetNewsBycid(int cid)
        {
            return dal.GetNewsBycid(cid);
        }
    }
}
