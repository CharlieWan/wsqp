using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MODEL
{
    public class Comment 
    {
        int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        DateTime vcreatedate;

        public DateTime Vcreatedate
        {
            get { return vcreatedate; }
            set { vcreatedate = value; }
        }
        string vname;

        public string Vname
        {
            get { return vname; }
            set { vname = value; }
        }
        string mobilephone;

        public string Mobilephone
        {
            get { return mobilephone; }
            set { mobilephone = value; }
        }
        string email;

        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        string ccontent;

        public string Ccontent
        {
            get { return ccontent; }
            set { ccontent = value; }
        }

        string ipaddress;

        public string Ipaddress
        {
            get { return ipaddress; }
            set { ipaddress = value; }
        }
        bool isdelete;

        public bool Isdelete
        {
            get { return isdelete; }
            set { isdelete = value; }
        }

        string subject;

        public string Subject
        {
            get { return subject; }
            set { subject = value; }
        }
    }
}
