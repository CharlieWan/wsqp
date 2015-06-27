using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace WSQP
{
    /// <summary>
    /// LoginAjax 的摘要说明
    /// </summary>
    public class LoginAjax : IHttpHandler,IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            string name = context.Request.Form["name"];
            string password = context.Request.Form["password"];
            int isp = context.Request.Form["isp"] == null ? 0 : 1;
            int flag = Convert.ToInt32(context.Request.Form["flag"]);
            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(password))
            {
                if (DoLogin(name.Trim(), password.Trim()) && flag == 1)
                {
                    context.Session["uinfo"] = name;
                    if (isp == 1)
                    {
                        HttpCookie ckUser = new HttpCookie("myCk");
                        ckUser.Values.Add("UserName", name);
                        ckUser.Expires.AddDays(7);
                    }
                    context.Response.Write("OK");
                }
                else
                {
                    context.Response.Write("Error");
                }
            }
        }


        bool DoLogin(string name, string password)
        {
            BLL.User bllUser = new BLL.User();
            return bllUser.Login(name, password) ? true : false;
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}