<%@ WebHandler Language="C#" Class="Vacode" %>

using System;
using System.Web;
using System.Drawing;
using System.Web.SessionState;

public class Vacode : IHttpHandler, IRequiresSessionState
{
    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "image/jpeg";
        string num;
        using (Bitmap img = new Bitmap(55, 25))
        {
            using (Graphics g = Graphics.FromImage(img))
            {
                Random ra = new Random();
                num = ra.Next(1000, 9999).ToString();
                //将生成的随机数验证码存放到Session中
                context.Session["code"] = num;
                //画图片的背景噪音线
                for (int i = 0; i < 25; i++)
                {
                    int x1 = ra.Next(img.Width);
                    int x2 = ra.Next(img.Width);
                    int y1 = ra.Next(img.Height);
                    int y2 = ra.Next(img.Height);
                    g.DrawLine(new Pen(Color.Silver), x1, y1, x2, y2);
                }
                //画图片的前景噪音点
                for (int i = 0; i < 100; i++)
                {
                    int x = ra.Next(img.Width);
                    int y = ra.Next(img.Height);
                    img.SetPixel(x, y, Color.FromArgb(ra.Next()));
                }
                Font font = new System.Drawing.Font("Arial", 12, (System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic));
                //System.Drawing.Drawing2D.LinearGradientBrush brush = new System.Drawing.Drawing2D.LinearGradientBrush(new Rectangle(0, 0, img.Width, img.Height), Color.Blue, Color.DarkRed, 1.2f, true);
                //g.DrawString(num, font, brush, 2, 2);
                g.DrawString(num, new Font("Arial", 14), Brushes.White, 2, 2);
                img.Save(context.Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                context.Response.End();
            }
        }
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
}