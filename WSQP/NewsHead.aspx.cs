using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace WSQP
{
    public partial class NewsHeader : System.Web.UI.Page
    {
        protected StringBuilder sbNewsCate = new StringBuilder(100);
        protected StringBuilder sbNews = new StringBuilder(1000);
        protected string catName;
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadNewsCate();
            int cid = string.IsNullOrEmpty(Request.QueryString["catid"]) ? 1 : Convert.ToInt32(Request.QueryString["catid"]);
            catName = GetNewCatNameById(cid);
            LoadNewsHead(cid);
        }

        void LoadNewsCate()
        {
            BLL.NewsCat bllNCate = new BLL.NewsCat();
            List<MODEL.NewsCat> list = bllNCate.GetAllNewsCategory();
            foreach (MODEL.NewsCat model in list)
            {
                sbNewsCate.Append("<li>");
                sbNewsCate.Append("<a href='NewsHead.aspx?catid=" + model.Id + "'>" + model.Name + "</a>");
                sbNewsCate.Append("</li>");
            }
        }

        void LoadNewsHead(int cid)
        {
            BLL.News bllNews = new BLL.News();
            List<MODEL.News> list = bllNews.GetAllNews(cid);
            foreach (MODEL.News model in list)
            {
                sbNews.Append("<li>");
                sbNews.Append("<a href='News.aspx?id=" + model.Id + "'>");
                sbNews.Append(model.Ntitle).Append("</a><span style='font-size:14px'>").Append(model.Ncreatedate.ToString("yyyy-MM-dd"));
                sbNews.Append("<span></li>");
            }
        }

        string GetNewCatNameById(int cid)
        {
            return new BLL.NewsCat().GetNewCatNameById(cid);
        }
    }
}