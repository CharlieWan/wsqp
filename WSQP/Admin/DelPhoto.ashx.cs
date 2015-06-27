using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.SessionState;

namespace WSQP
{
    /// <summary>
    /// DelPhoto 的摘要说明
    /// </summary>
    public class DelPhoto : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            BLL.Products bllPro = new BLL.Products();
            int id = Convert.ToInt32(context.Request.Form["id"]);
            if (bllPro.DeleteProduct(id))
            {
                context.Response.Write("OK");
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