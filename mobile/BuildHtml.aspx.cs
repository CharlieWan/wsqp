using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WSQPMobileSite
{
    public partial class BuildHtml : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string ck = Request.Params["ck"];
            string fold = Request.Params["fold"];
            if (ck == "1")
            {
                GenerateNewsHead();
                GenerateStaticHtml("/Article", "newsTemp.html");
                Response.End();
            }
            else if (ck == "2")
            {
                generatePhotoHtml(fold);
                Response.End();
            }
        }

        #region 生成新闻的标题页-void GenerateNewsHead()
        /// <summary>
        /// 生成新闻的标题页
        /// </summary>
        void GenerateNewsHead()
        {
            try
            {
                DirectoryInfo dir = new DirectoryInfo(Server.MapPath("/Article"));
                StringBuilder sb = new StringBuilder(10000);
                string content = File.ReadAllText(Server.MapPath("/NewsHeadTemp.html"));
                foreach (var file in dir.GetFiles())
                {
                    string fullText = File.ReadAllText(file.FullName);
                    string firstRow = (fullText.Split('\r'))[0];
                    int startindex = firstRow.IndexOf(">") + 1;
                    int endindex = firstRow.IndexOf("</h");
                    string nhead = firstRow.Substring(startindex, endindex - startindex);
                    sb.Append("<li><a href='html/" + file.Name.Substring(0, file.Name.Length - 4) + ".html'>" + nhead + "<span class='ui-li-count'>30</span></a></li>");
                    
                }
                content = content.Replace("{0}", sb.ToString());
                using (FileStream fs = File.Create(Server.MapPath("~") + "\\news.html"))
                {
                    byte[] headbyte = Encoding.UTF8.GetBytes(content);
                    fs.Write(headbyte, 0, headbyte.Length);
                }
                Response.Write("生成新闻标题"+Server.MapPath("~") + "\\news.html成功</br>");
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region 生成新闻具体的页面   -void GenerateStaticHtml(string folder, string tempName)
        /// <summary>
        /// 生成新闻具体的页面
        /// </summary>
        /// <param name="folder"></param>
        /// <param name="tempName"></param>
        void GenerateStaticHtml(string folder, string tempName)
        {
            try
            {
                string rootPath = Server.MapPath("~");
                string path = rootPath + folder;
                string newspath = Server.MapPath(tempName);          //读取模板文件
                string ul = File.ReadAllText(newspath);
                DirectoryInfo dir = new DirectoryInfo(path);
                FileInfo[] files = dir.GetFiles();
                for (int i = 0; i < files.Length; i++)
                {
                    if (files[i].Extension == ".txt")
                    {
                        string newsName = Server.MapPath("/html") + "\\"+ rep(files[i].Name);
                        using (FileStream fs = File.Create(newsName))
                        {
                            string newul = "";
                            if (i == 0)
                            {
                                newul = ul.Replace("{0}", File.ReadAllText(files[i].FullName)).Replace("{2}", rep(files[i + 1].Name)).Replace("{1}", rep(files[0].Name));
                            }
                            else if (i == files.Length - 1)
                            {
                                newul = ul.Replace("{0}", File.ReadAllText(files[i].FullName)).Replace("{2}", rep(files[files.Length - 1].Name)).Replace("{1}", rep(files[i - 1].Name));
                            }
                            else
                            {
                                newul = ul.Replace("{0}", File.ReadAllText(files[i].FullName)).Replace("{2}", rep(files[i + 1].Name)).Replace("{1}", rep(files[i - 1].Name));
                            }
                            byte[] bs = Encoding.UTF8.GetBytes(newul);
                            fs.Write(bs, 0, bs.Length);
                            Response.Write("生成新闻/html/" + rep(files[i].Name) + "成功！" + "</br>");
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region 生成产品图片页-oid generatePhotoHtml(string folderName)
        /// <summary>
        /// 生成产品图片页
        /// </summary>
        /// <param name="folderName"></param>
        void generatePhotoHtml(string folderName)
        {
            //得到模板文件的所有内容
            string con = File.ReadAllText(Server.MapPath("photoTemp.html"));
            StringBuilder sb = new StringBuilder(100000);
            //得到要保存的html文件的路径
            string phopath = Server.MapPath("/html");
            using (FileStream fs = new FileStream(phopath + "/" + folderName + ".html", FileMode.Create))
            {
                DirectoryInfo dir = new DirectoryInfo(Server.MapPath(folderName));
                FileInfo[] files = dir.GetFiles();
                foreach (var file in files)
                {
                    string fname = Path.GetFileNameWithoutExtension(file.Name);
                    sb.Append(@"<li><a href='#'  class='pics'  id='" + file.Name + "'><img src='" + folderName + "/" + file.Name + "'/>");
                    sb.Append("<h2>" + fname + "</h2>");
                    sb.Append(@"<p>" + folderName + "/" + file.Name + " </p>");
                    sb.Append("</a></li>");
                    Response.Write("生成图片" + file.Name + "成功!</br>");
                }
                Response.Write("成功" + files.Length + "个！");
                string newhtml = con.Replace("{0}", sb.ToString());
                byte[] bytehtml = Encoding.UTF8.GetBytes(newhtml);
                fs.Write(bytehtml, 0, bytehtml.Length);
            }
        }
        #endregion

        #region 替换txt文件为html文件-     string rep(string name)
        /// <summary>
        /// 替换txt文件为html文件
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        string rep(string name)
        {
            return name.Replace("txt", "html");
        }
        #endregion


        #region 递归搜索文件夹得到所有的文件+ public void FindFile(DirectoryInfo dir)
        /// <summary>
        /// 递归搜索文件夹得到所有的文件
        /// </summary>
        /// <param name="dir"></param>
        public void FindFile(DirectoryInfo dir)
        {
            FileSystemInfo[] infos = dir.GetFileSystemInfos();
            try
            {
                for (int i = 0; i < infos.Length; i++)  //查找子目录   
                {
                    if (infos[i] is FileInfo)
                    {
                        Context.Response.Write(infos[i] + "</br>");
                    }
                    else
                    {
                        DirectoryInfo di = infos[i] as DirectoryInfo;
                        FindFile(di);
                    }
                }
            }
            catch (Exception e)
            {

            }
        }
        #endregion

        //void GenerateNewsHtml()
        //{
        //    string path = Server.MapPath("/Article");
        //    DirectoryInfo dir = new DirectoryInfo(path);
        //    string p = Server.MapPath("/html");
        //    string temPath = Server.MapPath("template.html");
        //    FileInfo[] files = dir.GetFiles();
        //    StringBuilder sb = new StringBuilder(10000);
        //    for (int i = 0; i < files.Length; i++)
        //    {
        //        string content = File.ReadAllText(files[i].FullName);
        //        string teplatecontent = File.ReadAllText(temPath);
        //        //不带拓展名
        //        string filename = files[i].Name.Substring(0, files[i].Name.Length - 4);
        //        string htmlName = files[i].Name.Replace(".txt", ".html");
        //        //sb.Append(generateNewsHead(files[i]));
        //        string newcontent = teplatecontent.Replace("{0}", content).Replace("{1}", filename).Replace("{2}", "");
        //        using (FileStream fs = File.Create(p + "\\" + filename + ".html"))
        //        {
        //            byte[] bs = Encoding.UTF8.GetBytes(newcontent);
        //            fs.Write(bs, 0, bs.Length);
        //        }
        //    }
        //    string newspath = Server.MapPath("NewsTemp.html");
        //    string ul = File.ReadAllText(newspath);
        //    string newul = ul.Replace("{0}", sb.ToString());
        //    //Context.Response.Write(newul);
        //    using (FileStream fs = File.Create(Server.MapPath("~") + "\\News.html"))
        //    {
        //        byte[] bs = Encoding.UTF8.GetBytes(newul);
        //        fs.Write(bs, 0, bs.Length);
        //        //fs.Dispose();
        //    }
        //}

        #region void write(string oldpath, string newpath, params  string[] newcontents)
        /// <summary>
        /// void write(string oldpath, string newpath, params  string[] newcontents)
        /// </summary>
        /// <param name="oldpath"></param>
        /// <param name="newpath"></param>
        /// <param name="newcontents"></param>
        //void write(string oldpath, string newpath, params  string[] newcontents)
        //{
        //    StreamReader sr = new StreamReader(oldpath);
        //    string str = sr.ReadToEnd();
        //    sr.Close();
        //    //替换文本
        //    str = str.Replace("{0}", newcontents[0]);
        //    //更改保存文本
        //    StreamWriter sw = new StreamWriter(newpath, false);
        //    sw.WriteLine(str);
        //    sw.Close();
        //} 
        #endregion

    }
}