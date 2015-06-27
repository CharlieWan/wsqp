using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace WebApplication1
{
    /// <summary>
    /// GetPhoto 的摘要说明
    /// </summary>
    public class GetPhoto : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            string strid = context.Request.Params["id"];
            int id = Convert.ToInt32(strid);
            string s;
            switch (id)
            {
                case 1:
                    s = "/images";
                    break;
                default:
                    s = "/JAC";
                    break;
            }
            string path = context.Server.MapPath(s);
            DirectoryInfo dir = new DirectoryInfo(path);
            FileInfo[] files = dir.GetFiles();
            StringBuilder sb = new StringBuilder();
            int count = files.Length;
            foreach (var file in files)
            {
                string fname = Path.GetFileNameWithoutExtension(file.Name);
                sb.Append(@"<li data-corners='false' data-shadow='false' data-iconshadow='true' data-wrapperels='div' data-icon='arrow-r' data-iconpos='right' data-theme='c' class='ui-btn ui-btn-icon-right ui-li-has-arrow ui-li ui-li-has-thumb ui-first-child ui-btn-up-c'><div class='ui-btn-inner ui-li'><div class='ui-btn-text'><a href='#' class='cars ui-link-inherit' id='" + file.Name + "'><img src='" + s + "/" + file.Name + "' class='ui-li-thumb'/>");
                sb.Append("<h2 class='ui-li-heading'>" + fname + "</h2>");
                sb.Append(@"<p id='g' class='ui-li-desc'>" + fname + " </p><p class='ui-li-aside'>" + fname + "</p>");
                sb.Append("</a></li>");
            }
            context.Response.Write(sb);
        }

        public bool IsReusable
        {
            get
            {
                //<li data-corners="false" data-shadow="false" data-iconshadow="true" data-wrapperels="div" data-icon="arrow-r" data-iconpos="right" data-theme="c" class="ui-btn ui-btn-icon-right ui-li-has-arrow ui-li ui-li-has-thumb ui-first-child ui-btn-up-c"><div class="ui-btn-inner ui-li"><div class="ui-btn-text"><a href="#" class="cars ui-link-inherit" id="bmw"><img src="../../_assets/img/bmw-thumb.jpg" alt="BMW" class="ui-li-thumb"><h2 class="ui-li-heading">BMW</h2><p class="ui-li-desc">5 series</p></a></div><span class="ui-icon ui-icon-arrow-r ui-icon-shadow">&nbsp;</span></div></li>
                return false;
            }
        }
    }
}