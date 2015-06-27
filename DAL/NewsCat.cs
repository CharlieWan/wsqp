using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Text;
using System.Data;

namespace DAL
{
    public class NewsCat
    {
        public List<MODEL.NewsCat> GetNewsCategory()
        {
            string sql = "select  *  from  newsCat";
            DataTable dt = MySqlHelper.ExcuteDataTable(sql);
            List<MODEL.NewsCat> list = new List<MODEL.NewsCat>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    MODEL.NewsCat model = new MODEL.NewsCat();
                    LoadEntityData(model, dr);
                    list.Add(model);
                }
            }
            return list;
        }

        public void LoadEntityData(MODEL.NewsCat model,DataRow dr)
        {
            if (dr["id"] != null)
            {
                model.Id = Convert.ToInt32(dr["id"]);
            }
            if (dr["name"] != null)
            {
                model.Name = dr["name"].ToString();
            }
        }

        public string GetNewCatNameById(int id)
        {
            string sql = "select newsCat.name from newsCat where id=@id";
            MySqlParameter par = new MySqlParameter("@id", id);
            return MySqlHelper.ExcuteDataTable(sql, par).Rows[0][0].ToString();
        }
    }
}
