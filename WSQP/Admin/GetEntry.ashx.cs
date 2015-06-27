using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace WSQP.Admin
{
    /// <summary>
    /// GetEntry 的摘要说明
    /// </summary>
    public class GetEntry : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            int id = Convert.ToInt32(context.Request.QueryString["id"]);
            BLL.Entry bllEntry = new BLL.Entry();
            DataTable dt = bllEntry.GetPasswordById(id);
            string result = Dt2Json.DtToSON(dt);
            context.Response.Write(result);
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