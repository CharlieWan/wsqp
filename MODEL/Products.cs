using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MODEL
{
    [Serializable]
    public class Products
    {
        int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        int catid;

        public int Catid
        {
            get { return catid; }
            set { catid = value; }
        }
        string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        string path;

        public string Path
        {
            get { return path; }
            set { path = value; }
        }
        bool isdelete;

        public bool Isdelete
        {
            get { return isdelete; }
            set { isdelete = value; }
        }
    }
}
