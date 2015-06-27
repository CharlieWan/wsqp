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
    public partial class News : System.Web.UI.Page
    {
        protected StringBuilder sbHtml = new StringBuilder(1000);
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Context.Request.QueryString["id"]);
            BLL.News bllNews = new BLL.News();
          DataTable dt= bllNews.GetNewsById(id);
          sbHtml.Append(dt.Rows[0]["ncontent"]);
        }
    }
}