using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class ProductsCate
    {
        public List<MODEL.ProductsCate> GetAllProCate()
        {
            string sql = "select * from productscate where  productscate.id not in (select parentId  from  productscate) and isdelete=0";
            return MySqlHelper.ExcuteList<MODEL.ProductsCate>(sql);
        }
    }
}
