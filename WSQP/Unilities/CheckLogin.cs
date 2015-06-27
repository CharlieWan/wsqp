using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace WSQP
{
    public class CheckLogin : Page
    {
        protected override void OnInit(EventArgs e)
        {
            if (HttpContext.Current != null && Context.Session != null)
            {
                if (Session["uinfo"] == null || Session["uinfo"].ToString() == "")
                {
                    Session.Abandon();
                   Response.Write("<script>top.location.href='../Login.aspx?backurl=" + HttpContext.Current.Request.RawUrl + "'</script>");
                }
                base.OnInit(e);
            }
        }
    }
}