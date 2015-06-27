using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace WSQP
{
    /// <summary>
    /// verify 的摘要说明
    /// </summary>
    public class verify : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            string code = context.Request.Form["code"];
            if (!string.IsNullOrEmpty(code))
            {
                if (String.Compare(code, context.Session["code"].ToString()) == 0)
                {
                    context.Response.Write("OK");
                }
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