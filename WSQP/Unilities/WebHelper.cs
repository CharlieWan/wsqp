using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

namespace WSQP
{
    public class WebHelper
    {
        #region 01.从当前登录用户数据中，获得用户id，如果没有登录则返回0
        /// <summary>
        /// 从当前登录用户数据中，获得用户id，如果没有登录则返回0
        /// </summary>
        /// <returns></returns>
        public static int GetUserId()
        {
            //获得当前正在执行的上下文对象
            HttpContext context = HttpContext.Current;
            int res = 0;
            if (context.Request.Cookies["id"] != null)//如果cookie中有数据
            {
                res = Convert.ToInt32(context.Request.Cookies["id"].Value);
            }
            else if (context.Session["id"] != null)//如果session中有数据
            {
                res = Convert.ToInt32(context.Session["id"]);
            }
            return res;
        }
        #endregion

        #region 01.从当前登录用户数据中，获得用户id，如果没有登录则返回0
        /// <summary>
        /// 从当前登录用户数据中，获得用户id，如果没有登录则返回0
        /// </summary>
        /// <param name="url">返回路径</param>
        /// <param name="pageType">页面类型(1-父页面 ；2-子页面)</param>
        /// <returns></returns>
        public static int GetUserIdAndValidate(string url, int pageType)
        {
            int res = GetUserId();
            if (res == 0)
            {
                if (pageType == 1)//如果是在父页检查权限
                    WebHelper.WriteMsg("请登录～～～～", url);
                else if (pageType == 2)//如果是在子页检查权限
                    WebHelper.WriteMsgSon("请登录～～～～", url);
                HttpContext.Current.Response.End();
            }
            return res;
        }
        #endregion

        #region 02.输出js字符串
        /// <summary>
        /// 输出js字符串
        /// </summary>
        /// <param name="strMsg"></param>
        /// <param name="strUrl"></param>
        public static void WriteMsg(string strMsg, string strUrl)
        {
            HttpContext.Current.Response.Write("<script type='text/javascript'>alert('" + strMsg + "');window.location='" + strUrl + "';</script>");
        }
        public static void WriteMsg(string strMsg)
        {
            HttpContext.Current.Response.Write("<script type='text/javascript'>alert('" + strMsg + "');</script>");
        }
        #endregion

        #region 02.输出js字符串
        /// <summary>
        /// 输出js字符串
        /// </summary>
        /// <param name="strMsg"></param>
        /// <param name="strUrl"></param>
        public static void WriteMsgSon(string strMsg, string strUrl)
        {
            HttpContext.Current.Response.Write("<script type='text/javascript'>alert('" + strMsg + "');window.top.location='" + strUrl + "';</script>");
        }
        #endregion

        #region  03.获得MD5加密值
        /// <summary>
        /// 03.获得MD5加密值
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string MD5(string str)
        {
            return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(str, "md5").ToUpper();
        }
        #endregion

        #region 04.根据bool值输出 复选框 选中状态属性字符串
        /// <summary>
        /// 根据bool值输出 复选框 选中状态属性字符串
        /// </summary>
        /// <param name="isChecked"></param>
        /// <returns></returns>
        public static string GetChecked(bool isChecked)
        {
            return isChecked ? "checked='checked'" : "";
        }
        #endregion

        #region 05.获得状态选项下拉框选项 (状态 1-公开2-隐藏3-好友公开)
        /// <summary>
        /// 05.获得状态选项下拉框选项 
        /// </summary>
        /// <param name="statu">(状态 1-公开2-隐藏3-好友公开)</param>
        /// <returns></returns>
        public static string GetStatusOpts(int statu)
        {
            if (statu == 1)
            {
                return "<option value=\"1\" selected='true'>公开</option><option value=\"2\">仅自己可见</option><option value=\"3\">对好友公开</option>";
            }
            else if (statu == 2)
            {
                return "<option value=\"1\">公开</option><option value=\"2\" selected='true'>仅自己可见</option><option value=\"3\">对好友公开</option>";
            }
            else
                return "<option value=\"1\">公开</option><option value=\"2\">仅自己可见</option><option value=\"3\" selected='true'>对好友公开</option>";
        }
        #endregion

        #region +AJAX获得功能页码条
        /// <summary>
        /// AJAX获得功能页码条
        /// </summary>
        /// <param name="funName">js方法名</param>
        /// <param name="allrecord">全部记录条数</param>
        /// <param name="allpage">全部页面数</param>
        /// <param name="curpage">当前页码</param>
        /// <param name="groupsize">页码组大小</param>
        /// <param name="pagesize">页容量</param>
        public static string GetPageTxtAjax(string funName, int allrecord, int allpage, int curpage, int groupsize, int pagesize)
        {
            int curGroupPage = 0;
            StringBuilder test = new StringBuilder();
            StringBuilder test2 = new StringBuilder();
            StringBuilder pagetxt = new StringBuilder();
            if (curpage.Equals("") || curpage < 1) curpage = 1;
            if (allrecord.Equals("") || allrecord < 1) allrecord = 1;
            if (pagesize.Equals("") || pagesize < 1) pagesize = 1;
            if (allrecord == 0) { pagetxt.Append("页码：0/0 │ 共0条</TD> <td align='left'> 首页 << 上一页 | 1 >> | >> 尾页 &nbsp;&nbsp;</td></tr></table>"); }
            else
            {
                test2.Append(allpage.ToString());

                if (allpage.Equals("") || allpage < 1) allpage = 1;
                pagetxt.Append("页码：" + curpage.ToString() + "/" + allpage.ToString() + " │ 共" + allrecord.ToString() + "条");
                pagetxt.Append("<A href='javascript:" + funName + "(1)' title='首页'>1</A>&nbsp;");
                curGroupPage = (((curpage - 1) / groupsize) * groupsize) + 1;

                if (curGroupPage <= 1) pagetxt.Append("<a href='javascript:" + funName + "(" + curGroupPage + ")' title='回到首页'>&lt;&lt;</A>&nbsp;");
                else pagetxt.Append("<a href='javascript:" + funName + "(" + (curGroupPage - 1) + ")' title='前 " + groupsize + " 页'>&lt;&lt;</A>&nbsp;");

                if (curpage <= 1) pagetxt.Append("<A href='javascript:" + funName + "(" + curpage + ")' title='首页'><<</A>&nbsp;");
                else pagetxt.Append("<A href='javascript:" + funName + "(" + (curpage - 1) + ")' title='前一页'><<</A>&nbsp;");

                int tempI = 0;
                tempI = curGroupPage;//此时获得的是当前页码组的第一页
                do
                {
                    if (tempI == curpage) pagetxt.Append("<span class='nowpage'>" + tempI + "</span>&nbsp;");
                    else pagetxt.Append("<A href='javascript:" + funName + "(" + tempI + ")'>" + tempI + "</A>&nbsp;");
                    tempI = tempI + 1;
                } while (tempI < curGroupPage + groupsize && tempI <= allpage);//生成的页码不能大于 当前 页码组 的最大页，也不能大于 总页数

                if (curpage < allpage) pagetxt.Append("<A href='javascript:" + funName + "(" + (curpage + 1) + ")' title='后一页'>>></A>&nbsp;");
                else pagetxt.Append("<A href='javascript:" + funName + "(" + curpage + ")' title='后一页'>>></A>&nbsp;");

                if (curGroupPage + groupsize > allpage) pagetxt.Append("<a href='javascript:" + funName + "(" + allpage + ")' title='后 " + groupsize + " 页'>&gt;&gt;</A>&nbsp;");
                else pagetxt.Append("<a href='javascript:" + funName + "(" + (curGroupPage + groupsize) + ")' title='后" + groupsize + "页'>&gt;&gt;</A>&nbsp;");

                pagetxt.Append("<A href='javascript:" + funName + "(" + allpage + ")' title='最后一页'>" + allpage + "</A>");
            }
            test.Append("allpage=" + allpage + ",allrecord=" + allrecord + ",pagesize=" + pagesize + ",groupsize=" + groupsize + ",curGroupPage=" + curGroupPage + ",curpage=" + curpage);
            return pagetxt.ToString();
        }
        #endregion

        #region +WEBFORM获得功能页码条
        /// <summary>
        /// WEBFORM获得功能页码条
        /// </summary>
        /// <param name="url">页码连接地址</param>
        /// <param name="searcheurl">搜索url</param>
        /// <param name="allrecord">全部记录条数</param>
        /// <param name="allpage">全部页面数</param>
        /// <param name="curpage">当前页码</param>
        /// <param name="groupsize">页码组大小</param>
        /// <param name="pagesize">页容量</param>
        public static string  GetPageTxt(string url, string searcheurl, int allrecord, int allpage, int curpage, int groupsize, int pagesize)
        {
            int curGroupPage = 0;
            StringBuilder test = new StringBuilder();
            StringBuilder test2 = new StringBuilder();
            StringBuilder pagetxt = new StringBuilder();
            if (curpage.Equals("") || curpage < 1) curpage = 1;
            if (allrecord.Equals("") || allrecord < 1) allrecord = 1;
            if (pagesize.Equals("") || pagesize < 1) pagesize = 1;
            if (allrecord == 0) { pagetxt.Append("页码：0/0 │ 共0条 </TD> <td align='left'> 首页 << 上一页 | 1 >> | >> 尾页 &nbsp;&nbsp;</td></tr></table>"); }
            else
            {
                test2.Append(allpage.ToString());

                if (allpage.Equals("") || allpage < 1) allpage = 1;
                pagetxt.Append("页码：" + curpage.ToString() + "/" + allpage.ToString() + " │ 共" + allrecord.ToString() + "条");
                pagetxt.Append("<A href='" + url + "1' title='首页'>1</A>&nbsp;");
                curGroupPage = (((curpage - 1) / groupsize) * groupsize) + 1;

                if (curGroupPage <= 1) pagetxt.Append("<a href='" + url + curGroupPage + searcheurl + "' title='回到首页'>&lt;&lt;</A>&nbsp;");
                else pagetxt.Append("<a href='" + url + (curGroupPage - 1) + searcheurl + "' title='前 " + groupsize + " 页'>&lt;&lt;</A>&nbsp;");

                if (curpage <= 1) pagetxt.Append("<A href='" + url + curpage + searcheurl + "' title='首页'><</A>&nbsp;");
                else pagetxt.Append("<A href='" + url + (curpage - 1) + searcheurl + "' title='前一页'><</A>&nbsp;");

                int tempI = 0;
                tempI = curGroupPage;
                do
                {
                    if (tempI == curpage) pagetxt.Append("<span class='nowpage'>" + tempI + "</span>&nbsp;");
                    else pagetxt.Append("<A href='" + url + tempI + searcheurl + "'>" + tempI + "</A>&nbsp;");
                    tempI = tempI + 1;
                } while (tempI < curGroupPage + groupsize && tempI <= allpage);

                if (curpage < allpage) pagetxt.Append("<A href='" + url + (curpage + 1) + searcheurl + "' title='后一页'>></A>&nbsp;");
                else pagetxt.Append("<A href='" + url + curpage + searcheurl + "' title='后一页'>></A>&nbsp;");

                if (curGroupPage + groupsize > allpage) pagetxt.Append("<a href='" + url + allpage + searcheurl + "' title='后 " + groupsize + " 页'>&gt;&gt;</A>&nbsp;");
                else pagetxt.Append("<a href='" + url + (curGroupPage + groupsize) + searcheurl + "' title='后" + groupsize + "页'>&gt;&gt;</A>&nbsp;");

                pagetxt.Append("<A href='" + url + allpage + searcheurl + "' title='最后一页'>" + allpage + "</A>");
            }
            test.Append("allpage=" + allpage + ",allrecord=" + allrecord + ",pagesize=" + pagesize + ",groupsize=" + groupsize + ",curGroupPage=" + curGroupPage + ",curpage=" + curpage);
            return pagetxt.ToString();
        }
        #endregion

        public static  StringBuilder  GetPageBar(int recordCount,int pageVolume)
        {
            StringBuilder sb = new StringBuilder(1000);
            if (recordCount == 0)
            {
                sb.Append("no data!");
            }
            else
            {
                int pageCount = recordCount / pageVolume + 1; 
                sb.Append("共有").Append(recordCount).Append("条记录");
                for (int i = 1; i <= pageCount; i++)
                {
                    sb.Append("<a href=Products.aspx?pid=").Append(i).Append(">"+i+"</a>");
                }
            }
            return sb;
        }
    }
}