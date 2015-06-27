using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Web.Script.Serialization;

namespace WSQP.Admin
{
    /// <summary>
    /// DelNews 的摘要说明
    /// </summary>
    public class DelNews : IHttpHandler,IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            int nid=Convert.ToInt32(context.Request.QueryString["nid"]);
            try
            {
                BLL.News bllNews=new BLL.News();
                if (bllNews.DelNews(nid))
                {
                    context.Response.Write("OK");
                }
                else
                {
                    context.Response.Write("FAIL!");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            //JavaScriptSerializer jss = new JavaScriptSerializer();
            //string strJson = jss.Serialize(list);
            
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