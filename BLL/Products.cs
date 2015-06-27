using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BLL
{
    public class Products
    {
        DAL.Products dalPro = new DAL.Products();
        public bool AddProducts(MODEL.Products modelPro)
        {
            return dalPro.AddProducts(modelPro) > 0 ? true : false;
        }

        public List<MODEL.Products> GetProductsByCid(int cid)
        {
            return dalPro.GetProductsByCid(cid);
        }

        public bool DeleteProduct(int id)
        {
            return dalPro.DeleteProduct(id) > 0 ? true : false;
        }

        public int UpdateFileName(int id, string newName)
        {
            return dalPro.UpdateFileName(id, newName);
        }

        public DataTable GetPagedListByProc(int cid)
        {
            return dalPro.GetPagedListByProc(cid);
        }

        public DataTable GetPagedList(int cid,int pageid,int pageCount)
        {
            return dalPro.GetPagedList(cid,pageid,pageCount);
        }

        public int GetRecordCount(int cid)
        {
            return dalPro.GetRecordCount(cid);
        }
    }
}
