using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.SessionState;
using System.Web.Script.Serialization;

namespace WSQP.Admin
{
    /// <summary>
    /// AjaxGetPhoto 的摘要说明
    /// </summary>
    public class AjaxGetPhoto : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            BLL.Products bllPro=new BLL.Products();
            int cid = Convert.ToInt32(context.Request.Form["catid"]);
            List<MODEL.Products> list = bllPro.GetProductsByCid(cid);
            JavaScriptSerializer jss = new JavaScriptSerializer();
            context.Response.Write(jss.Serialize(list));
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