using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using System.Web;
using System.Data;

namespace WSQP
{
    /// <summary>
    /// GetProData 的摘要说明
    /// </summary>
    public class GetProData : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            BLL.Products bllPro = new BLL.Products();
            int cid = Convert.ToInt32(context.Request.Form["cid"]);
            int pid = Convert.ToInt32(context.Request.QueryString["pid"]);
            DataTable dt = bllPro.GetPagedList(cid,pid,10);
            //JavaScriptSerializer jss = new JavaScriptSerializer();
            context.Response.Write(dt);
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