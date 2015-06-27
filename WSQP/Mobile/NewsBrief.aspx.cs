using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace WSQP.Mobile
{
    public partial class NewsBrief : System.Web.UI.Page
    {
        protected string NewsCatName;
        protected StringBuilder sbHtml = new StringBuilder(1000);
        protected void Page_Load(object sender, EventArgs e)
        {
            int cid = Convert.ToInt32(Context.Request.QueryString["cid"]);
            BLL.NewsCat bllNewsCat = new BLL.NewsCat();
            NewsCatName = bllNewsCat.GetNewCatNameById(cid);
            BLL.News bllNews = new BLL.News();
            List<MODEL.News> list = bllNews.GetNewsBycid(cid);
            foreach (var i in list)
            { 
                sbHtml.Append("<li><a href='News.aspx?id="+i.Id+"'>");
                sbHtml.Append(i.Ntitle);
                sbHtml.Append("</a></li>");
            }
        }

    }
}