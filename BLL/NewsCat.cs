using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BLL
{
   public  class NewsCat
    {
       DAL.NewsCat dalNewsCat = new DAL.NewsCat();
       public List<MODEL.NewsCat> GetAllNewsCategory()
       {
           return dalNewsCat.GetNewsCategory();
       }

       public string GetNewCatNameById(int id)
       {
           return dalNewsCat.GetNewCatNameById(id);
        }
    }
}
