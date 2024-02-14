using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Configuration;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Collections;
using System.Text;


namespace SifirGibiMakina
{
    public class Translate
    {

        public Translate()
        {

        }



        public static string BaslikCevir(string Ceviri)
        {
            string url = "https://translation.googleapis.com/language/translate/v2?key=" + ConfigurationManager.AppSettings["GoogleTransleteApiKey"];
            //url += "&source=TR";
            url += "&target=EN";
            url += "&q=" + WebUtility.UrlEncode(Ceviri);
            WebClient client = new WebClient();
            client.Encoding = System.Text.Encoding.UTF8;
            string json = client.DownloadString(url);
            JsonData jsonData = (new JavaScriptSerializer()).Deserialize<JsonData>(json);
            return jsonData.Data.Translations[0].TranslatedText;
        }

        public static string OtomatikCeviri(string Ceviri, string CevrilecekDil)
        {
            try
            {
                string url = "https://translation.googleapis.com/language/translate/v2?key=" + ConfigurationManager.AppSettings["GoogleTransleteApiKey"];
                //url += "&source=TR";
                url += "&target=" + CevrilecekDil;
                url += "&q=" + WebUtility.UrlEncode(Ceviri);
                WebClient client = new WebClient();
                client.Encoding = System.Text.Encoding.UTF8;
                string json = client.DownloadString(url);
                JsonData jsonData = (new JavaScriptSerializer()).Deserialize<JsonData>(json);
                return jsonData.Data.Translations[0].TranslatedText;
            }
            catch (Exception ex)
            {
                return "...";
            }


        }

        public string AciklamaCevir(string Ceviri)
        {
            try
            {
                string url = "https://translation.googleapis.com/language/translate/v2?key=" + ConfigurationManager.AppSettings["GoogleTransleteApiKey"];
                //url += "&source=TR";
                url += "&target=EN";
                url += "&q=" + WebUtility.UrlEncode(Ceviri);
                WebClient client = new WebClient();
                client.Encoding = System.Text.Encoding.UTF8;
                string json = client.DownloadString(url);
                JsonData jsonData = (new JavaScriptSerializer()).Deserialize<JsonData>(json);
                return jsonData.Data.Translations[0].TranslatedText;
            }
            catch (Exception ex)
            {
                return "...";
            }

        }

        public class JsonData
        {
            public Data Data { get; set; }
        }

        public class Data
        {
            public List<Translation> Translations { get; set; }
        }

        public class Translation
        {
            public string TranslatedText { get; set; }
        }
    }
}