using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WSQP
{
    public partial class Products : System.Web.UI.Page
    {
        protected StringBuilder sbLeft = new StringBuilder(1000);
        protected StringBuilder sbHtml = new StringBuilder(2000);
        protected String pageText;
        int pageCount = 20;
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadLeftMenu();
            int cid = String.IsNullOrEmpty(Request.QueryString["cid"]) ? 1 : Convert.ToInt32(Request.QueryString["cid"]);
            int pid = String.IsNullOrEmpty(Request.QueryString["pid"]) ? 1 : Convert.ToInt32(Request.QueryString["pid"]);
            int all = GetRecordCount(cid);
            LoadPhoto(cid, pid);
            loadPageList(all, cid, pid);
        }

        void LoadPhoto(int cid, int pid)
        {
            BLL.Products bllPro = new BLL.Products();
            DataTable dt = bllPro.GetPagedList(cid, pid, pageCount);
            if (dt.Rows.Count == 0)
            {
                sbHtml.Append("没有数据！");
            }
            else
            {
                foreach (DataRow row in dt.Rows)
                {
                    sbHtml.Append("<li>");
                    sbHtml.Append("<a href='" + row["path"] + "' class='fancybox' data-fancybox-group='gallery'><img src=" + row["path"] + " class='fancybox-image'></a>").Append(row["name"]);
                    sbHtml.Append("</li>");
                }
            }
        }

        void LoadLeftMenu()
        {
            BLL.ProductsCate bllProCate = new BLL.ProductsCate();
            List<MODEL.ProductsCate> list = bllProCate.GetAllProCate();
            foreach (MODEL.ProductsCate model in list)
            {
                sbLeft.Append("<ul class='l_top'>");
                sbLeft.Append("<li class='first'>");
                sbLeft.Append(model.Catname).Append("</li>");
                sbLeft.Append("<li><a href='Products.aspx?cid=" + model.Id + "'>");
                sbLeft.Append(model.Catname).Append("</a></li></ul>");
            }
        }

        int GetRecordCount(int catid)
        {
            BLL.Products bllPro = new BLL.Products();
            return bllPro.GetRecordCount(catid);
        }

        void loadPageList(int all, int cid, int pid)
        {
            pageText = WebHelper.GetPageTxt("Products.aspx?cid=" + cid + "&pid=", "", all, all / pageCount + 1, pid, 3, pageCount);
        }
    }
}