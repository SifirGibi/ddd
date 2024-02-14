using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.Helpers.ReWriterPathHelper
{
    public static class URLHelper
    {
        public static string RewritePath(string newsID, string strTitle, int tip)
        {
            strTitle = RewriteTitle(strTitle);

            switch (tip)
            {
                case 1:
                    return strTitle;
                case 2:
                    return $"{newsID}_{strTitle}.aspx";
                case 3:
                    return $"Makale/{DateTime.Now.Date.Year}/{DateTime.Now.Date.Month}/{DateTime.Now.Date.Day}/{newsID}-{strTitle}.aspx";
                default:
                    return "default.aspx";
            }
        }

        private static string RewriteTitle(string strTitle)
        {
            strTitle = strTitle.Trim();

            strTitle = strTitle.Trim('-');
            strTitle = strTitle.ToLower();

            char[] chars = @"$%#@!*?;:~`+=()[]{}|\'<>,/^&"".".ToCharArray();

            strTitle = strTitle.Replace("c#", "C-Sharp");
            strTitle = strTitle.Replace("vb.net", "VB-Net");
            strTitle = strTitle.Replace("asp.net", "Asp-Net");
            strTitle = strTitle.Replace("-", "");
            strTitle = strTitle.Replace(" ", "-");
            strTitle = strTitle.Replace("ç", "c");
            strTitle = strTitle.Replace("ğ", "g");
            strTitle = strTitle.Replace("ı", "i");
            strTitle = strTitle.Replace("ö", "o");
            strTitle = strTitle.Replace("ş", "s");
            strTitle = strTitle.Replace("ü", "u");
            strTitle = strTitle.Replace("\"", "");
            strTitle = strTitle.Replace("/", "");
            strTitle = strTitle.Replace("(", "");
            strTitle = strTitle.Replace(")", "");
            strTitle = strTitle.Replace("{", "");
            strTitle = strTitle.Replace("}", "");
            strTitle = strTitle.Replace("%", "");
            strTitle = strTitle.Replace("&", "");
            strTitle = strTitle.Replace("+", "");
            strTitle = strTitle.Replace(".", "-");
            strTitle = strTitle.Replace("?", "");
            strTitle = strTitle.Replace(",", "");
            strTitle = strTitle.Replace("--", "-");
            strTitle = strTitle.Replace("---", "-");
            strTitle = strTitle.Replace("----", "-");
            strTitle = strTitle.Replace("-----", "-");
            strTitle = strTitle.Replace("----", "-");
            strTitle = strTitle.Replace("---", "-");
            strTitle = strTitle.Replace("--", "-");

            // Lüzumsuz karakterleri de bi güzel çevirelim 
            for (int i = 0; i < chars.Length; i++)
            {
                string strChar = chars.GetValue(i).ToString();
                if (strTitle.Contains(strChar))
                {
                    strTitle = strTitle.Replace(strChar, string.Empty);
                }
            }

            strTitle = strTitle.Trim();
            strTitle = strTitle.Trim('-');

            return strTitle;
        }
    }
}