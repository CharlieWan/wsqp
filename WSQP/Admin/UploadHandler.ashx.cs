using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace WSQP.Admin
{
    /// <summary>
    /// UploadHandler 的摘要说明
    /// </summary>
    public class UploadHandler : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            MODEL.Products model = new MODEL.Products();
            model.Catid = Convert.ToInt32(context.Request.QueryString["cid"]);
            HttpPostedFile files = context.Request.Files["fileData"];
            string fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + DateTime.Now.Millisecond;
            string uploadPath = context.Server.MapPath("/upload");
            string fileExtension = Path.GetExtension(files.FileName);
            model.Path = "upload/" + fileName + fileExtension;
            model.Name = files.FileName;
            BLL.Products bllPro = new BLL.Products();
            if (bllPro.AddProducts(model))
            {
                files.SaveAs(uploadPath + "\\" + fileName +fileExtension);
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