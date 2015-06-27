using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Text;

namespace DAL
{
    public class Products
    {
        public int AddProducts(MODEL.Products modelPro)
        {
            string sql = "insert into Products(catid,name,path) values(@cid,@name,@path)";
            MySqlParameter[] pars ={
                                new MySqlParameter("@cid",modelPro.Catid),
                                new MySqlParameter("@name",modelPro.Name),
                                new MySqlParameter("@path",modelPro.Path)
                                };
            return MySqlHelper.ExcuteNonQuery(sql, pars);
        }

        public List<MODEL.Products> GetProductsByCid(int cid)
        {
            string sql = "select  * from  Products where isdelete=0 and catid=@cid";
            MySqlParameter sp = new MySqlParameter("@cid", cid);
            return MySqlHelper.ExcuteList<MODEL.Products>(sql, sp);
        }

        public int DeleteProduct(int id)
        {
            string sql = "update Products set isdelete=1 where id=@id";
            MySqlParameter sp = new MySqlParameter("@id", id);
            return MySqlHelper.ExcuteNonQuery(sql, sp);
        }

        public int UpdateFileName(int id, string newName)
        {
            string sql = "update Products set name=@newName where id=@id";
            MySqlParameter[] paras ={
                                     new MySqlParameter("@id",id),
                                     new MySqlParameter("@newName",newName)
                                 };
            return MySqlHelper.ExcuteNonQuery(sql, paras);
        }

        int pagecount = 0, rowcount = 0;
        public DataTable GetPagedListByProc(int cid)
        {
            return DbHelperSQL.GetPageListByProc("up_GetPagedProducts", 1, 16, cid, out pagecount, out rowcount);
        }

        public DataTable GetPagedList(int cid, int pageId,int pageSize)
        {
            string sql = @"select * from products where catid=@cid and  isdelete=0  LIMIT  @startIndex,@pc";
            MySqlParameter[] sp ={ 
                                      new MySqlParameter("@cid", cid), 
                                      new MySqlParameter("@pc",pageSize),
                                      new MySqlParameter("@startIndex",(pageId-1)*pageSize)         
                                        };
            return MySqlHelper.ExcuteDataTable(sql, sp);
        }

        public int GetRecordCount(int cid)
        {
            string sql = "select count(1) from  Products where catid=@cid and isdelete=0";
            MySqlParameter par = new MySqlParameter("@cid", cid);
            return Convert.ToInt32(MySqlHelper.ExcuteScalar(sql, par));
        }
    }
}
