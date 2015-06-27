using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WSQP.Admin
{
    /// <summary>
    /// EditFileName 的摘要说明
    /// </summary>
    public class EditFileName : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            BLL.Products bllPro = new BLL.Products();
            int id = Convert.ToInt32(context.Request.Form["id"]);
            string newName = context.Request.Form["newName"];
            if (bllPro.UpdateFileName(id, newName) > 0)
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