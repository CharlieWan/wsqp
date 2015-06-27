using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Text;

namespace WSQP
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string from = "wanweiv@126.com";
            string fromname = "Charlie wan";
            string to = "charlieb@live.cn";
            string subject = "reset-password";
            string body = "Please click below link to reset-password";
            string username = "wanweiv@126.com";
            string password = "wan0716weibb";
            string server = "smtp.126.com";  
            string fujian = " ";
            SendMail(from, fromname, to, subject, body, username, password, server, fujian);
            Context.Response.Write("SEND OK!");
        }

        private string SendMail(string from, string fromname, string to, string subject, string body, string username, string password, string server, string fujian)
        {

            try
            {

                SmtpClient client = new SmtpClient(server);
                client.EnableSsl = true;
                //邮件发送类 

                MailMessage mail = new MailMessage();

                //是谁发送的邮件 

                mail.From = new MailAddress(from, fromname);

                //发送给谁 

                mail.To.Add(to);

                //标题 

                mail.Subject = subject;

                //内容编码 

                mail.BodyEncoding = Encoding.Default;

                //发送优先级 

                mail.Priority = MailPriority.High;

                //邮件内容 

                mail.Body = body;

               

                //是否HTML形式发送 

                mail.IsBodyHtml = true;

                //附件 

                if (fujian.Length > 0)
                {

                    mail.Attachments.Add(new Attachment(fujian));

                }

                //邮件服务器和端口 

                SmtpClient smtp = new SmtpClient(server, 25);

                smtp.UseDefaultCredentials = true;

                //指定发送方式 

                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

                //指定登录名和密码 

                smtp.Credentials = new System.Net.NetworkCredential(username, password);

                //超时时间 

                smtp.Timeout = 10000;

                smtp.Send(mail);

                return "send ok";

            }

            catch (Exception exp)
            {

                return exp.Message;

            }

        }
    }
}