using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace WSQP.Admin
{
    /// <summary>
    /// SubmitModifyPassword 的摘要说明
    /// </summary>
    public class SubmitModifyPassword : IHttpHandler,IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
               string strName =context.Session["uinfo"].ToString();
                string newPassword =context.Request.Form["newPassword"];
                if (new BLL.User().ModifyPassword(strName, newPassword))
                {
                   context.Response.Write("OK");
                }
                else
                {
                    context.Response.Write("error");
                }
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