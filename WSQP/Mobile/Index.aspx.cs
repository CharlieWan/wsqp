using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;

namespace WSQP.Mobile
{
    public partial class Index1 : System.Web.UI.Page
    {
        protected StringBuilder productTitle = new StringBuilder(1000);
        protected StringBuilder newsTitle = new StringBuilder(1000);
        protected void Page_Load(object sender, EventArgs e)
        {
            BLL.ProductsCate bllPcate = new BLL.ProductsCate();
            List<MODEL.ProductsCate> list= bllPcate.GetAllProCate();
            BLL.Products bllPro = new BLL.Products();
                  //<li><a href="html/lhq2.html">好斯基 <span class="ui-li-count">62</span></a></li>
            foreach (var item in list)
            {
                int ProductCount = bllPro.GetRecordCount(item.Id);
                productTitle.Append("<li><a href='Products.aspx?cid=" + item.Id + "'>");
                productTitle.Append(item.Catname);
                productTitle.Append("<span class='ui-li-count'>");
                productTitle.Append(ProductCount);
                productTitle.Append("</span></a></li>");
            }
            GenerateNewsTitle();
        }

        void GenerateNewsTitle()
        { 
           // <li><a href="news.html">公司新闻 <span class="ui-li-count">12</span></a></li>
            BLL.NewsCat bllNewscat = new BLL.NewsCat();
            BLL.News bllNews = new BLL.News();
            List<MODEL.NewsCat> list= bllNewscat.GetAllNewsCategory();
            foreach (var item in list)
            {
                newsTitle.Append("<li><a href=NewsBrief.aspx?cid="+item.Id+">");
                newsTitle.Append(item.Name);
                newsTitle.Append("<span class='ui-li-count'>");
                newsTitle.Append(bllNews.GetNewsCountByCid(item.Id));
                newsTitle.Append("</span></a></li>");
            }
        }
    }
}