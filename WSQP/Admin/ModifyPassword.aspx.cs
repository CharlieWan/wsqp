using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WSQP.Admin
{
    public partial class ModifyPassword : CheckLogin
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                string strName = Session["uinfo"].ToString();
                string newPassword = Request.Form["cPassword"];
                if (new BLL.User().ModifyPassword(strName, newPassword))
                {
                    Response.Write("<script>msgObj.ShowMsgInfo('密码修改成功!');</script>");
                }
                else
                {
                    Response.Write("<script>msgObj.ShowMsgInfo('内部错误!');</script>");
                }
            }
        }
    }
}