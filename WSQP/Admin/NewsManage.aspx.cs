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
    public partial class NewsManage : CheckLogin
    {
        protected StringBuilder htmlData = new StringBuilder(1000);
        protected void Page_Load(object sender, EventArgs e)
        {
            BLL.News BllNews = new BLL.News();
            DataTable dtNews = BllNews.GetAllNews();
            foreach (DataRow dr in dtNews.Rows)
            {
                htmlData.Append("<tr class='info'><td>"+dr["id"]+"</td>");
                htmlData.Append("<td>"+dr["ntitle"]+"</td><td>");
                htmlData.Append("<a href='javascript:void(0)' onclick='del(this)' id='"+dr["id"]+"' role='button'><i class='icon-remove'></i></a>");
                htmlData.Append("  <a href='EditNews.aspx?id="+dr["id"]+"'><i class='icon-pencil' style='padding-left:15px'></i></a>");
                htmlData.Append("</td></tr>");
            }
            htmlData.Append("</tbody></table>");
        }
    }
}
