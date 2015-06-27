using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WSQP.Admin
{
    public partial class ViewPass : System.Web.UI.Page
    {
        protected StringBuilder sbHtml = new StringBuilder(5000);
        //protected StringBuilder sbPop = new StringBuilder(3000);
        protected void Page_Load(object sender, EventArgs e)
        {
            BLL.Entry bllEntry = new BLL.Entry();
            DataTable dtEntryGroup = bllEntry.GetAllEntryGroup();
            foreach (DataRow dr in dtEntryGroup.Rows)
            {
                DataTable dtEntries = bllEntry.GetEntriesByGid(Convert.ToInt32(dr["id"]));
                sbHtml.Append("<div data-role=\"collapsible\">");
                sbHtml.Append("<h2>" + dr["Groupname"] + "</h2>");
                sbHtml.Append("<ul data-role=\"listview\">");
                foreach (DataRow row in dtEntries.Rows)
                {
                    sbHtml.Append("<li><a href='#detail' onclick='showDetail(this)' valu='" + row["id"] + "'");
                    sbHtml.Append("data-rel=\"popup\" data-position-to=\"window\" data-transition=\"pop\">");
                    sbHtml.Append(row["title"]);
                    sbHtml.Append("</a></li>");

                    //sbPop.Append("<div data-role='popup'  id='pop"+row["id"]+"' data-theme='d' data-overlay-theme='b'  class='ui-content'  style='max-width:340px; padding-bottom:2em;'>");
                    //sbPop.Append("<h3><a href='" + row["url"] + "'  target=\"_blank\">" + row["title"] + "</a></h3>");
                    //sbPop.Append("<p>用户名:" + row["username"] + "</p>");
                    //sbPop.Append("<p>失效日期:" + row["expiresDate"] + "</p>");
                    //sbPop.Append("<p>备注:" + row["notes"] + "</p>");
                    //sbPop.Append("<a href='ViewPass.aspx' data-role='button' data-rel='back' data-theme='b' data-icon='check' data-inline='true' data-mini='true'>OK</a></div>");
                }
                sbHtml.Append("</ul></div>");
            }
        }
    }
}
