using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;

namespace WSQP.Mobile
{
    public partial class Products : System.Web.UI.Page
    {
        protected string proName;
        protected StringBuilder sbHtml = new StringBuilder(1000);
        protected void Page_Load(object sender, EventArgs e)
        {
            int cid = Convert.ToInt32(Context.Request.QueryString["cid"]);
            // int pageId = Context.Request.QueryString["pageId"] == null ? 1 : Convert.ToInt32(Context.Request.QueryString["pageId"]);
            int pageId = 1;
            BLL.Products bllPro = new BLL.Products();
            DataTable dt = bllPro.GetPagedList(cid, pageId, 10);
            if (dt.Rows.Count == 0)
                sbHtml.Append("没有数据！");
            else
            {
                foreach (DataRow dr in dt.Rows)
                {
                    sbHtml.Append("<li><a href='#'  class='pics'  id=" + Convert.ToInt32(dr["id"]) + ">");
                    sbHtml.Append("<img src=../" + dr["path"] + "><h2>" + dr["name"] + "</h2><p>" + dr["name"] + " </p></a></li>");
                }
            }
        }
    }
}