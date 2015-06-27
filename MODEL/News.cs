using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MODEL
{
    public class News
    {
        int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        string ntitle;

        public string Ntitle
        {
            get { return ntitle; }
            set { ntitle = value; }
        }
        string ncontent;

        public string Ncontent
        {
            get { return ncontent; }
            set { ncontent = value; }
        }
        DateTime ncreatedate;

        public DateTime Ncreatedate
        {
            get { return ncreatedate; }
            set { ncreatedate = value; }
        }
        string author;

        public string Author
        {
            get { return author; }
            set { author = value; }
        }
        bool isdelete;

        public bool Isdelete
        {
            get { return isdelete; }
            set { isdelete = value; }
        }

        int catid;

        public int Catid
        {
            get { return catid; }
            set { catid = value; }
        }
    }
}
