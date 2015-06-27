using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;
using System.Data;
using System.Net;
using System.Net.Sockets;

namespace WSQP
{
    public partial class FeedBack : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                MODEL.Comment comModel = new MODEL.Comment();
                comModel.Vname = Request.Form["userName"];
                comModel.Email = Request.Form["Email"];
                comModel.Subject = Request.Form["Title"];
                comModel.Ccontent = Request.Form["Content"];
                comModel.Mobilephone = Request.Form["Phone"];
                string messageIP = string.Empty;
                IPAddress[] arrIPAddresses = Dns.GetHostAddresses(Dns.GetHostName());
                foreach (IPAddress ip in arrIPAddresses)
                {
                    if (ip.AddressFamily.Equals(AddressFamily.InterNetwork))
                    {
                        messageIP = ip.ToString();
                    }
                }
                comModel.Ipaddress = messageIP;
                BLL.Comment bllObj = new BLL.Comment();
                if (bllObj.AddComment(comModel) > 0)
                {
                    Response.Write("<script>alert('你的问题我们已收到,Thanks!');window.location='index.aspx';</script>");
                }
            }
        }
    }
}