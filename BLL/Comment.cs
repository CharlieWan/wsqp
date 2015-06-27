using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class Comment
    {
        DAL.Comment dalCom = new DAL.Comment();
        public List<MODEL.Comment> GetList()
        {
            return dalCom.GetAllComments();
        }

        public int AddComment(MODEL.Comment model)
        {
            return dalCom.AddComment(model);
        }
    }
}
