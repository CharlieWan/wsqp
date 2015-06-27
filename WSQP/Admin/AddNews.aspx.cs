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
    public partial class AddNews : CheckLogin
    {
        protected StringBuilder sbNewsCate = new StringBuilder(200);
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadNewsCat();
            if (IsPostBack)
            {
                MODEL.News model = new MODEL.News();
                model.Ntitle = Request.Form["title"];
                model.Ncontent = Request.Form["editor01"];
                model.Catid = Convert.ToInt32(Request.Form["selNewsCate"]);
                BLL.News bllNews = new BLL.News();
                if (bllNews.AddNews(model))
                {
                    Response.Write("<script>alert('添加成功！')</script>");
                }
                else
                {
                    Response.Write("失败！请重试！");
                }
            }
        }

        void LoadNewsCat()
        {
            BLL.NewsCat bllNewsCate = new BLL.NewsCat();
            List<MODEL.NewsCat> listNewsCate = bllNewsCate.GetAllNewsCategory();
            foreach (MODEL.NewsCat model in listNewsCate)
            {
                sbNewsCate.Append("<option value='" + model.Id + "'>");
                sbNewsCate.Append(model.Name);
                sbNewsCate.Append("</option>");
            }
        }
    }
}
