using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace note3_ex3
{
    public partial class Mail_ex1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            List<RowOfData> data = new List<RowOfData> { r, r };
            ErrorOfReceiveData(data, "Testing");
        }

        readonly RowOfData r = new RowOfData()
        {
            PART_NO = "test",
            WO_NO = "test",
            SHIP_NO = "test",
            PALLET_NO = "test",
            CARTON_NO = "test",
            ID1 = "test",
            ID2 = "test",
            ID3 = "test",
            ID4 = "test",
            ID5 = "test",
            ID6 = "test",
            ID7 = "test",
            ID8 = "test",
            ID9 = "test",
            ID10 = "test",
            ID11 = "test",
            ID12 = "test",
            ID13 = "test",
            ID14 = "test",
            ID15 = "test",
            ID16 = "test",
            ID17 = "test",
            ID18 = "test",
            ID19 = "test",
            ID20 = "test",
            CREATE_TIME = "2021-05-06"
        };


        //readonly string ErrMsg = " <br/> Post 過來的資料已化為 ReceivedData.csv 附檔<br/><br/>錯誤訊息 : <br/><br/>";
        //readonly string ErrMsg = " <br/><br/>錯誤訊息 : <br/><br/>";
       
        /// <summary>
        /// 產生檔案
        /// </summary>
        public void ErrorOfReceiveData(List<RowOfData> rds, string Msg)
        {
            // 內容
            var content = " <html><br/><br/>錯誤訊息 : <br/><br/>" + Msg.Replace("\n", "<br/></html>");
            // 附檔
            MemoryStream ms = new MemoryStream();
            using (var file = new StreamWriter(ms))
            {
                foreach (var item in rds)
                {
                    file.WriteLineAsync($"{item.PART_NO},{item.WO_NO},{item.SHIP_NO},{item.PALLET_NO},{item.CARTON_NO}" +
                        $",{item.ID1},{item.ID2},{item.ID3},{item.ID4},{item.ID5},{item.ID6},{item.ID7},{item.ID8},{item.ID9},{item.ID10}" +
                        $",{item.ID11},{item.ID12},{item.ID13},{item.ID14},{item.ID15},{item.ID6},{item.ID17},{item.ID18},{item.ID19},{item.ID20}" +
                        $",{ item.CREATE_TIME}");
                }
            }
            SendWithAttachment("kate_jou@askey.com", "note3_ex3_Mail_ex1", content, ms);
        }
        
        /// <summary>
        /// 
        /// </summary>
        void SendWithAttachment(string sendTo, string subject, string content, MemoryStream ms)
        {
            try
            {
                //using (SmtpClient sc = new SmtpClient("smtp.askey.com.tw"))
                using (SmtpClient sc = new SmtpClient("localhost"))
                {
                    using (MailMessage mm = new MailMessage("Testing@askey.com", sendTo, subject, content))
                    {
                        mm.Attachments.Add(new Attachment(new MemoryStream(ms.ToArray()), "ReceivedData.csv", "text/csv"));
                        mm.IsBodyHtml = true;
                        sc.Send(mm);
                    }
                }
                Label1.Text = "成功";
            }
            catch (Exception ex)
            {
                string errMsg = "方法︰SendWithAttachment \nsendTo : " + sendTo + "\nsubjec : " + subject + "\ncontent ︰" + content + "\n\nError ︰ " + ex.ToString();
                Do.WriteLog(errMsg, "Mail_Error_Log");
                Label1.Text = "失敗";
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                MailMessage m = new MailMessage("FromMe@me.com", "ToMe@me.com", "TestSubject", "TestBody");
                SmtpClient client = new SmtpClient("localhost");
                client.Send(m);
                Label2.Text = "成功";
            }
            catch 
            {
                Label2.Text = "失敗";
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            MailMessage m = new MailMessage("FromMe@me.com", "ToMe@me.com", "TestSubject", "TestBody");
            SmtpClient sc = new SmtpClient("localhost");
            sc.SendCompleted += new SendCompletedEventHandler(sc_SendCompleted);
            sc.SendAsync(m,null);
            //sc.SendAsyncCancel();
        }


        void sc_SendCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Cancelled)
                Label3.Text = "郵件取消";
            else if (e.Error != null)
                Label3.Text = "郵件發生錯誤";
            else
                Label3.Text = "郵件成功";
        }

    }
}