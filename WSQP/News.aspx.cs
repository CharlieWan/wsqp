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
    public partial class News : System.Web.UI.Page
    {
        protected StringBuilder sbContent = new StringBuilder(50000);
        protected StringBuilder sbNavi = new StringBuilder(100);
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = string.IsNullOrEmpty(Request.QueryString["id"]) ? 1 : Convert.ToInt32(Context.Request.QueryString["id"]);
            LoadNews(id);
            LoadNavigator(id);
        }

        BLL.News bllNews = new BLL.News();

        void LoadNews(int id)
        {
            DataTable dt = bllNews.GetNewsById(id);
            foreach (DataRow row in dt.Rows)
            {
                sbContent.Append(row["Ncontent"]);
            }
        }

        void LoadNavigator(int id)
        {
            DataTable dt = bllNews.GetNewsCount();
            int minId = Convert.ToInt32(dt.Rows[0][1]);
            int maxId = Convert.ToInt32(dt.Rows[0][0]);
            if (id == minId)
            {
                sbNavi.Append("上一篇：已经是第一篇了！<br>");
                sbNavi.Append("下一篇：<a href='News.aspx?id=" + (id + 1) + "'>" + GetTitlebyId(id + 1) + "</a>");
            }
            else if (id == maxId)
            {
                sbNavi.Append("上一篇：<a href='News.aspx?id=" + (id - 1) + "'>" + GetTitlebyId(id - 1) + "</a><br>");
                sbNavi.Append("下一篇：已经是最后一篇了！");
            }
            else
            {
                sbNavi.Append("上一篇：<a href='News.aspx?id=" + (id - 1) + "'>" + GetTitlebyId(id - 1) + "</a><br>");
                sbNavi.Append("下一篇：<a href='News.aspx?id=" + (id + 1) + "'>" + GetTitlebyId(id + 1) + "</a>");
            }
        }

        string GetTitlebyId(int id)
        {
            if (id > 0)
            {
                DataTable dt = bllNews.GetNewsById(id);
                return dt.Rows[0][1].ToString();
            }
            return "";
        }
    }
}