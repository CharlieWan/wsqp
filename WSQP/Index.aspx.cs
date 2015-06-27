using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WSQP
{
    public partial class Index : System.Web.UI.Page
    {
        protected StringBuilder indexNews = new StringBuilder(1000);
        protected void Page_Load(object sender, EventArgs e)
        {
            BLL.News bllNews = new BLL.News();
            DataTable dt = bllNews.GetTop7();
            foreach (DataRow dr in dt.Rows)
            {
                string title = dr["ntitle"].ToString();
                string showtitle = title.Length > 18 ? title.Substring(0, 18) + "..." : title;
                indexNews.Append("<li>");
                indexNews.Append("<a href='News.aspx?id="+Convert.ToInt32(dr["id"])+"'>"+showtitle+"");
                indexNews.Append("<span style='float:right'>"+((DateTime)dr["ncreatedate"]).ToString("MM-dd")+"<span>");
                indexNews.Append("</a></li>");
            }
        }
    }
}