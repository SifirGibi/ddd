using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Net.Mail;
using System.Net;
using System.Web.Configuration;
using System.Net.Configuration;
using System.IO;

namespace SifirGibiMakina
{
    public class Mailler
    {
        string duzenlibirim = "";
        public Mailler()
        {

        }

        public string Send_EMail(string Baslik, string Icerik, string Kime, string AttachmentPath)
        {

            try
            {
                db_SifirGibiMakinaEntities nt = new db_SifirGibiMakinaEntities();
                var Sorgu = from c in nt.tbl_Ayarlar
                            select c;

                foreach (var prod in Sorgu)
                {
                    //Eğer kime kısmı boşsa otomatik teknik kişilere gönderilecek
                    if (Kime=="")
                    {
                        Kime = prod.TeknikKisiler;
                    }
                   

                Icerik = Icerik + "<meta http-equiv=\"Content-Type\" content=\"text/html; charset=iso-8859-9\">";
                //Microsoft un MailMessage classı kullanılmıştır. 2.0 olanı yenilenmiş
                MailMessage MAIL = new MailMessage();
                MAIL.From = new MailAddress(prod.SMTP_Email, prod.SMTP_Gonderen);
                MAIL.To.Add(Kime);
                MAIL.Subject = prod.Site_Adi + "-" + Baslik;
                MAIL.Body = Icerik;
                MAIL.IsBodyHtml = true;//Mail formatının HTML olması gerektiğini gösterir.
                MAIL.Priority = MailPriority.High;//Mailin Önceliğini gösterir 
                MAIL.BodyEncoding = System.Text.Encoding.UTF8;

                if (AttachmentPath.Trim() != "")
                {
                    Attachment MyAttachment = new Attachment(AttachmentPath);
                    MAIL.Attachments.Add(MyAttachment);
                }
                    //ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

                    SmtpClient server = new SmtpClient(prod.SMTP_Server, Convert.ToInt32(prod.SMTP_Port));
                    server.EnableSsl = true;
                    //server.UseDefaultCredentials = false;
                    server.Credentials = new NetworkCredential(prod.SMTP_Mail, prod.SMTP_Sifre);
                    server.Send(MAIL);
                }

                return "Başarılı";
            }

            catch(Exception ex)
            {
                return "Başarısız" + ex;

            }

        }

        public string Send_EMailMessage(string Baslik, string Icerik, string Kime, string Kimden)
        {

            try
            {
                db_SifirGibiMakinaEntities nt = new db_SifirGibiMakinaEntities();
                var Sorgu = from c in nt.tbl_Ayarlar
                            select c;

                foreach (var prod in Sorgu)
                {
                    //Eğer kime kısmı boşsa otomatik teknik kişilere gönderilecek
                    if (Kime == "")
                    {
                        Kime = prod.TeknikKisiler;
                    }


                    Icerik = Icerik + "<meta http-equiv=\"Content-Type\" content=\"text/html; charset=iso-8859-9\">";
                    //Microsoft un MailMessage classı kullanılmıştır. 2.0 olanı yenilenmiş
                    MailMessage MAIL = new MailMessage();
                    MAIL.From = new MailAddress(prod.SMTP_Email, prod.SMTP_Gonderen);
                    MAIL.To.Add(Kime);
                    MAIL.ReplyToList.Add(Kimden);
                    MAIL.Subject = prod.Site_Adi + "-" + Baslik;
                    MAIL.Body = Icerik;
                    MAIL.IsBodyHtml = true;//Mail formatının HTML olması gerektiğini gösterir.
                    MAIL.Priority = MailPriority.High;//Mailin Önceliğini gösterir 
                    MAIL.BodyEncoding = System.Text.Encoding.UTF8;

                    
                    //ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

                    SmtpClient server = new SmtpClient(prod.SMTP_Server, Convert.ToInt32(prod.SMTP_Port));
                    server.EnableSsl = true;
                    //server.UseDefaultCredentials = false;
                    server.Credentials = new NetworkCredential(prod.SMTP_Mail, prod.SMTP_Sifre);
                    server.Send(MAIL);
                }

                return "Başarılı";
            }

            catch (Exception ex)
            {
                return "Başarısız" + ex;

            }

        }

        public static string ReadFile(string path)
        {
            string s = string.Empty;
            try
            {
                HttpWebRequest web =
                    (HttpWebRequest)HttpWebRequest.Create(path);
                HttpWebResponse resp = (HttpWebResponse)web.GetResponse();
                web.ContentType = "text/html; charset=iso-8859-9";
                StreamReader sr = new StreamReader(resp.GetResponseStream());
                s = sr.ReadToEnd();
                sr.Close();
            }
            catch (Exception e)
            {
                return e.Message;
            }
            finally
            {

            }

            return s;
        }

        public string SetYeniUyelikMailBody(string txtEmail, string txtSifre, string txtAdSoyad)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            string body = ReadFile(ConfigurationManager.AppSettings["YeniKayitMailHTML"]);

            //Kisisel Bilgiler
            body = body.Replace("[email]", txtEmail);
            body = body.Replace("[sifre]", txtSifre);
            body = body.Replace("[adsoyad]", txtAdSoyad);

            return body;
        }

        public string SetIlanKaldirildiMail(string ilanno, string ilanadi, string ilanresim, string ilanfiyat, string parabirimi)
        {

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            string body = ReadFile(ConfigurationManager.AppSettings["IlanYayindanKaldirildiMailHTML"]);

            //Para Birimi
            if (parabirimi == "1")
            {
                duzenlibirim = " &#8378";

            }
            else if (parabirimi == "2")
            {
                duzenlibirim = " &euro;";

            }
            else if (parabirimi == "3")
            {
                duzenlibirim = " $";

            }


            body = body.Replace("[ilanno]", ilanno);
            body = body.Replace("[ilanbaslik]", ilanadi);
            body = body.Replace("6d1c24b188de4376afb5ffbe4b70d38f_1.jpeg", "https://sifirgibimakine.com/admin/Uploads/" + ilanresim);
            body = body.Replace("[fiyat]", ilanfiyat.ToString());
            body = body.Replace("[parabirimi]", duzenlibirim);
            body = body.Replace("[kaldirilmatarihi]", DateTime.Now.ToString());

            return body;
        }

        public string SetMakineDegerlendirmeMail(string ilanadi, string ilanresim, string ilanfiyat, string parabirimi)
        {

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            string body = ReadFile(ConfigurationManager.AppSettings["MakineDegerlemeMailHTML"]);

            //Para Birimi
            if (parabirimi == "1")
            {
                duzenlibirim = " &#8378";

            }
            else if (parabirimi == "2")
            {
                duzenlibirim = " &euro;";

            }
            else if (parabirimi == "3")
            {
                duzenlibirim = " $";

            }


            body = body.Replace("[kayittarihi]", DateTime.Now.ToString());
            body = body.Replace("[ilanbaslik]", ilanadi);
            body = body.Replace("6d1c24b188de4376afb5ffbe4b70d38f_1.jpeg", "https://sifirgibimakine.com/admin/Uploads/" + ilanresim);
            body = body.Replace("[talepedilenfiyat]", ilanfiyat.ToString());
            body = body.Replace("[talepfiyatparabirimi]", duzenlibirim);


            return body;
        }

        public string SetIlanMesajMail(string ilanno, string ilanadi, string ilanresim, string ilanfiyat, string parabirimi, string mesajID, string mesaj, string adsoyad, string gonderenadsoyad)
        {

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            string body = ReadFile(ConfigurationManager.AppSettings["IlanMesajMailHTML"]);

            //Para Birimi
            if (parabirimi == "1")
            {
                duzenlibirim = " &#8378";

            }
            else if (parabirimi == "2")
            {
                duzenlibirim = " &euro;";

            }
            else if (parabirimi == "3")
            {
                duzenlibirim = " $";

            }


            body = body.Replace("[ilanno]", ilanno);
            body = body.Replace("[ilanbaslik]", ilanadi);
            body = body.Replace("6d1c24b188de4376afb5ffbe4b70d38f_1.jpeg", "https://sifirgibimakine.com/admin/Uploads/" + ilanresim);
            body = body.Replace("[fiyat]", ilanfiyat.ToString());
            body = body.Replace("[parabirimi]", duzenlibirim);
            body = body.Replace("[mesajID]", mesajID);
            body = body.Replace("[mesaj]", mesaj);
            body = body.Replace("[adsoyad]", adsoyad);
            body = body.Replace("[gonderenadsoyad]", gonderenadsoyad);
            body = body.Replace("[gonderilmetarihi]", DateTime.Now.ToString());

            return body;
        }
        
        public string SetIlanMesajCevapMail(string ilanno, string ilanadi, string ilanresim, string ilanfiyat, string parabirimi, string ustmesajID, string mesaj, string adsoyad, string gonderenadsoyad)
        {

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            string body = ReadFile(ConfigurationManager.AppSettings["IlanMesajCevapMailHTML"]);

            //Para Birimi
            if (parabirimi == "1")
            {
                duzenlibirim = " &#8378";

            }
            else if (parabirimi == "2")
            {
                duzenlibirim = " &euro;";

            }
            else if (parabirimi == "3")
            {
                duzenlibirim = " $";

            }


            body = body.Replace("[ilanno]", ilanno);
            body = body.Replace("[ilanbaslik]", ilanadi);
            body = body.Replace("6d1c24b188de4376afb5ffbe4b70d38f_1.jpeg", "https://sifirgibimakine.com/admin/Uploads/" + ilanresim);
            body = body.Replace("[fiyat]", ilanfiyat.ToString());
            body = body.Replace("[parabirimi]", duzenlibirim);
            body = body.Replace("[mesajID]", ustmesajID);
            body = body.Replace("[mesaj]", mesaj);
            body = body.Replace("[adsoyad]", adsoyad);
            body = body.Replace("[gonderenadsoyad]", gonderenadsoyad);
            body = body.Replace("[gonderilmetarihi]", DateTime.Now.ToString());

            return body;
        }

        public string SetIlanMailMesaji(string ilanno, string ilanadi, string ilanresim, string ilanfiyat, string parabirimi, string mesaj, string adsoyad, string gonderenadsoyad, string aciklama, string baslik)
        {

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            string body = ReadFile(ConfigurationManager.AppSettings["IlanEmailMesajiHTML"]);

            //Para Birimi
            if (parabirimi == "1")
            {
                duzenlibirim = " &#8378";

            }
            else if (parabirimi == "2")
            {
                duzenlibirim = " &euro;";

            }
            else if (parabirimi == "3")
            {
                duzenlibirim = " $";

            }


            body = body.Replace("[ilanno]", ilanno);
            body = body.Replace("[ilanbaslik]", ilanadi);
            body = body.Replace("6d1c24b188de4376afb5ffbe4b70d38f_1.jpeg", "https://sifirgibimakine.com/admin/Uploads/" + ilanresim);
            body = body.Replace("[fiyat]", ilanfiyat.ToString());
            body = body.Replace("[parabirimi]", duzenlibirim);
            body = body.Replace("[mesaj]", mesaj);
            body = body.Replace("[adsoyad]", adsoyad);
            body = body.Replace("[gonderenadsoyad]", gonderenadsoyad);
            body = body.Replace("[gonderilmetarihi]", DateTime.Now.ToString());
            body = body.Replace("[aciklama]", aciklama);
            body = body.Replace("[baslik]", baslik);

            return body;
        }

    }
}