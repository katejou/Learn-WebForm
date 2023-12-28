using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace LocalMail
{
    class Program
    {
        static void Main(string[] args)
        {
            SmtpClient smtp = new SmtpClient();
            MailMessage msg = new MailMessage();
            msg.From = new MailAddress("test@askey.com", "寄件者");  // 寄件者
            msg.To.Add(new MailAddress("kate_jou@askey.com", "收件者"));    //收件者
            msg.Subject = "主旨"; // 主旨
            msg.Body = "內文"; // 內文
            smtp.Send(msg);
        }
    }
}