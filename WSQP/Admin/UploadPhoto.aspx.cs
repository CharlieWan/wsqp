using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WSQP
{
    public partial class UploadPhoto:CheckLogin
    {
        protected StringBuilder cateHtml = new StringBuilder(200);
        protected void Page_Load(object sender, EventArgs e)
        {
            BLL.ProductsCate bllProCate = new BLL.ProductsCate();
            List<MODEL.ProductsCate> list = bllProCate.GetAllProCate();
            foreach (MODEL.ProductsCate model in list)
            {
                cateHtml.Append("<option value=");
                cateHtml.Append(model.Id).Append(">");
                cateHtml.Append(model.Catname);
                cateHtml.Append("</option>");
            }
        }
    }
}