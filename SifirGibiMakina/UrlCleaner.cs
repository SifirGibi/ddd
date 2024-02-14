using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SifirGibiMakina;

namespace SifirGibiMakina
{
    public static class UrlCleaner
    {

        public static string UrlCevir(this string kelime)
        {
            if (kelime == "" || kelime == null) { return ""; }
            kelime = kelime.Replace("A", "a");
            kelime = kelime.Replace("B", "b");
            kelime = kelime.Replace("C", "c");
            kelime = kelime.Replace("ç", "c");
            kelime = kelime.Replace("Ç", "c");
            kelime = kelime.Replace("D", "d");
            kelime = kelime.Replace("E", "e");
            kelime = kelime.Replace("F", "f");
            kelime = kelime.Replace("G", "g");
            kelime = kelime.Replace("ğ", "g");
            kelime = kelime.Replace("Ğ", "g");
            kelime = kelime.Replace("ı", "i");
            kelime = kelime.Replace("I", "i");
            kelime = kelime.Replace("İ", "i");
            kelime = kelime.Replace("H", "h");
            kelime = kelime.Replace("J", "j");
            kelime = kelime.Replace("K", "k");
            kelime = kelime.Replace("L", "l");
            kelime = kelime.Replace("M", "m");
            kelime = kelime.Replace("N", "n");
            kelime = kelime.Replace("O", "o");
            kelime = kelime.Replace("ö", "o");
            kelime = kelime.Replace("Ö", "o");
            kelime = kelime.Replace("P", "p");
            kelime = kelime.Replace("R", "r");
            kelime = kelime.Replace("S", "s");
            kelime = kelime.Replace("Ş", "s");
            kelime = kelime.Replace("ş", "s");
            kelime = kelime.Replace("T", "t");
            kelime = kelime.Replace("U", "u");
            kelime = kelime.Replace("ü", "u");
            kelime = kelime.Replace("Ü", "u");
            kelime = kelime.Replace("V", "v");
            kelime = kelime.Replace("Y", "y");
            kelime = kelime.Replace("Z", "z");
            kelime = kelime.Replace("W", "w");
            kelime = kelime.Replace("Q", "q");
            kelime = kelime.Replace("ß", "b");
            kelime = kelime.Replace("ä", "a");
            kelime = kelime.Replace("Ä", "a");
            kelime = kelime.Replace(".", "");
            kelime = kelime.Replace(":", "");
            kelime = kelime.Replace(";", "");
            kelime = kelime.Replace(",", "");
            kelime = kelime.Replace(" ", "-");
            kelime = kelime.Replace("!", "");
            kelime = kelime.Replace("(", "");
            kelime = kelime.Replace(")", "");
            kelime = kelime.Replace("'", "");
            kelime = kelime.Replace("`", "");
            kelime = kelime.Replace("=", "");
            kelime = kelime.Replace("&", "");
            kelime = kelime.Replace("%", "");
            kelime = kelime.Replace("#", "");
            kelime = kelime.Replace("<", "");
            kelime = kelime.Replace(">", "");
            kelime = kelime.Replace("*", "");
            kelime = kelime.Replace("?", "");
            kelime = kelime.Replace("+", "-");
            kelime = kelime.Replace("\"", "-");
            kelime = kelime.Replace("»", "-");
            kelime = kelime.Replace("|", "-");
            kelime = kelime.Replace("^", "");
            kelime = kelime.Replace("/", "-");
            return kelime;
        }
    }
}