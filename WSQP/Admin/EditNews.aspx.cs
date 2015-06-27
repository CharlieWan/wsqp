using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WSQP.Admin
{
    public partial class EditNews : CheckLogin
    {
        protected string title, content;
        protected StringBuilder sbNewsCate = new StringBuilder(300);
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadNewsCat(LoadOldNews());
            if (IsPostBack)
            {
                MODEL.News model = new MODEL.News();
                model.Id = Convert.ToInt32(Context.Request.QueryString["id"]);
                model.Catid = Convert.ToInt32(Request.Form["selNewsCate"]);
                model.Ntitle = Request.Form["title"];
                model.Ncontent = Request.Form["myeditor"];
                BLL.News bllNews = new BLL.News();
                if (bllNews.ModifyNews(model) > 0)
                {
                    Context.Response.Write("<script>alert('修改成功啦！')</script>");
                }
            }
        }

        int  LoadOldNews()
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);
            BLL.News bllNews = new BLL.News();
            DataTable dt = bllNews.GetNewsById(id);
            title = dt.Rows[0][1].ToString();
            content = dt.Rows[0][2].ToString();
            return  Convert.ToInt32(dt.Rows[0][5]);
        }

        void LoadNewsCat(int newcatId)
        {
            BLL.NewsCat bllNewsCate = new BLL.NewsCat();
            List<MODEL.NewsCat> listNewsCate = bllNewsCate.GetAllNewsCategory();
            foreach (MODEL.NewsCat model in listNewsCate)
            {
                string str = model.Id == newcatId ? " selected":" ";
                sbNewsCate.Append("<option value='" + model.Id + "'").Append(str).Append(">");
                sbNewsCate.Append(model.Name);
                sbNewsCate.Append("</option>");
            }
        }
    }
}