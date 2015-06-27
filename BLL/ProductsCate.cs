using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class ProductsCate
    {
        DAL.ProductsCate dalProCate = new DAL.ProductsCate();
        public List<MODEL.ProductsCate> GetAllProCate()
        {
            return dalProCate.GetAllProCate();
        }
    }
}
