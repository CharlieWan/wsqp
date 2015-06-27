using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MODEL
{
    public class ProductsCate
    {
        int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        string catname;

        public string Catname
        {
            get { return catname; }
            set { catname = value; }
        }

        bool isdelete;

        public bool Isdelete
        {
            get { return isdelete; }
            set { isdelete = value; }
        }
    }
}
