using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Data;
using System.Data.OleDb;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace WSQP
{
    public partial class Visitor:CheckLogin
    {
        protected StringBuilder sbHtml = new StringBuilder(1000);
        protected void Page_Load(object sender, EventArgs e)
        {
            string flag = Request.QueryString["flag"]; 
            //GenerateHtml();  
            if (flag != null)
            {
                Session.Abandon();
                Response.Write("OK");
                Response.End();
            }
            BLL.Comment bllObj = new BLL.Comment();
            List<MODEL.Comment> list = bllObj.GetList();
            //this.GridView1.DataSource = list;
            //this.GridView1.DataBind();
            sbHtml.Append("<table class='table'>");
            sbHtml.Append("<thread><tr><th>创建日期<th><th>姓名<th><th>主题<th><th>手机号吗<th><th>email地址<th><th>内容<th><th>ip地址<th></tr></thread><tbody>");
            foreach (var item in list)
            {
                sbHtml.Append("<tr>");
                sbHtml.Append("<td>"+item.Vcreatedate.ToString("yyyy-MM-dd")+"<td>");
                sbHtml.Append("<td>" + item.Vname + "<td>");
                sbHtml.Append("<td>" + item.Subject + "<td>");
                sbHtml.Append("<td>" + item.Mobilephone + "<td>");
                sbHtml.Append("<td>" + item.Email + "<td>");
                sbHtml.Append("<td>" + item.Ccontent + "<td>");
                sbHtml.Append("<td>" + item.Ipaddress + "<td>");
                sbHtml.Append("</tr></tbody>");
                //sbHtml.Append("<td><a href='javacript:void(0)' role='button' data-toggle='modal'><i class='icon-remove'></i></a></td>");
            }
            sbHtml.Append("</tbody></table>");
        }

        //void GenerateHtml()
        //{
        //    string path = Server.MapPath("Visitor.xml");
        //    XmlDocument doc = new XmlDocument();
        //    doc.Load(path);
        //    XmlNode node;
        //    XmlNodeList lists = doc.DocumentElement.ChildNodes;
        //    for (int i = 0; i < lists.Count; i++)//对根子节点的所有子节点进行循环       
        //    {
        //        node = lists[i];
        //        if (node.HasChildNodes)//判断是否还有子节点          
        //        {
        //            sb.Append(@"<tr onmouseover=this.style.backgroundColor='#ffff66'; onmouseout=this.style.backgroundColor='#d4e3e5';>");
        //            for (int j = 0; j < node.ChildNodes.Count; j++)
        //            {
        //                XmlNode childnode = node.ChildNodes[j];
        //                sb.Append("<td>").Append(childnode.InnerText).Append("</td>");
        //            }
        //            sb.Append("</tr>");
        //        }
        //    }
        //}
    }
}