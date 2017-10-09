using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyBenhVien.Helpers
{
    public partial class StringClearFormat
    {
        // - Clear special characters.
        public static string formatInput(object stringinput)
        {
            string stringoutput;
            stringoutput = stringinput.ToString().Replace("'", "&#146;");
            stringoutput = stringinput.ToString().Replace("script", "&#115;cript");
            stringoutput = stringinput.ToString().Replace("SCRIPT", "&#083;CRIPT");
            stringoutput = stringinput.ToString().Replace("Script", "&#083;cript");
            stringoutput = stringinput.ToString().Replace("script", "&#083;cript");
            stringoutput = stringinput.ToString().Replace("object", "&#111;bject");
            stringoutput = stringinput.ToString().Replace("OBJECT", "&#079;BJECT");
            stringoutput = stringinput.ToString().Replace("Object", "&#079;bject");
            stringoutput = stringinput.ToString().Replace("object", "&#079;bject");
            stringoutput = stringinput.ToString().Replace("applet", "&#097;pplet");
            stringoutput = stringinput.ToString().Replace("APPLET", "&#065;PPLET");
            stringoutput = stringinput.ToString().Replace("Applet", "&#065;pplet");
            stringoutput = stringinput.ToString().Replace("applet", "&#065;pplet");
            stringoutput = stringinput.ToString().Replace("event", "&#101;vent");
            stringoutput = stringinput.ToString().Replace("EVENT", "&#069;VENT");
            stringoutput = stringinput.ToString().Replace("Event", "&#069;vent");
            stringoutput = stringinput.ToString().Replace("event", "&#069;vent");
            stringoutput = stringinput.ToString().Replace("document", "&#100;ocument");
            stringoutput = stringinput.ToString().Replace("DOCUMENT", "&#068;OCUMENT");
            stringoutput = stringinput.ToString().Replace("Document", "&#068;ocument");
            stringoutput = stringinput.ToString().Replace("document", "&#068;ocument");
            stringoutput = stringinput.ToString().Replace("cookie", "&#099;ookie");
            stringoutput = stringinput.ToString().Replace("COOKIE", "&#067;OOKIE");
            stringoutput = stringinput.ToString().Replace("Cookie", "&#067;ookie");
            stringoutput = stringinput.ToString().Replace("cookie", "&#067;ookie");
            stringoutput = stringinput.ToString().Replace("form", "&#102;orm");
            stringoutput = stringinput.ToString().Replace("FORM", "&#070;ORM");
            stringoutput = stringinput.ToString().Replace("Form", "&#070;orm");
            stringoutput = stringinput.ToString().Replace("form", "&#070;orm");
            stringoutput = stringinput.ToString().Replace("iframe", "i&#102;rame");
            stringoutput = stringinput.ToString().Replace("IFRAME", "I&#070;RAME");
            stringoutput = stringinput.ToString().Replace("Iframe", "I&#102;rame");
            stringoutput = stringinput.ToString().Replace("iframe", "i&#102;rame");
            stringoutput = stringinput.ToString().Replace("textarea", "&#116;extarea");
            stringoutput = stringinput.ToString().Replace("TEXTAREA", "&#84;EXTAREA");
            stringoutput = stringinput.ToString().Replace("Textarea", "&#84;extarea");
            stringoutput = stringinput.ToString().Replace("textarea", "&#84;extarea");
            stringoutput = stringinput.ToString().Replace("input", "&#073;nput");
            stringoutput = stringinput.ToString().Replace("Input", "&#073;nput");
            stringoutput = stringinput.ToString().Replace("INPUT", "&#073;nput");
            stringoutput = stringinput.ToString().Replace("input", "&#073;nput");
            stringoutput = stringinput.ToString().Replace("<", "&lt;");
            stringoutput = stringinput.ToString().Replace(">", "&gt;");
            stringoutput = stringinput.ToString().Replace("'", "''");
            stringoutput = stringinput.ToString().Replace("=", "&#061;");
            stringoutput = stringinput.ToString().Replace("select", "sel&#101;ct");
            stringoutput = stringinput.ToString().Replace("join", "jo&#105;n");
            stringoutput = stringinput.ToString().Replace("union", "un&#105;on");
            stringoutput = stringinput.ToString().Replace("where", "wh&#101;re");
            stringoutput = stringinput.ToString().Replace("insert", "ins&#101;rt");
            stringoutput = stringinput.ToString().Replace("delete", "del&#101;te");
            stringoutput = stringinput.ToString().Replace("update", "up&#100;ate");
            stringoutput = stringinput.ToString().Replace("like", "lik&#101;");
            stringoutput = stringinput.ToString().Replace("drop", "dro&#112;");
            stringoutput = stringinput.ToString().Replace("create", "cr&#101;ate");
            stringoutput = stringinput.ToString().Replace("modify", "mod&#105;fy");
            stringoutput = stringinput.ToString().Replace("rename", "ren&#097;me");
            stringoutput = stringinput.ToString().Replace("alter", "alt&#101;r");
            stringoutput = stringinput.ToString().Replace("cast", "ca&#115;t");


            return stringoutput;
        }
        public static string ClearCharacterSpecial(string Name)
        {
            string strValue = string.Empty;
            if (!string.IsNullOrEmpty(Name))
            {
                strValue = Name.ToLower();

                // - Special with char 'A'
                strValue = strValue.Replace("à", "a").Replace("á", "a").Replace("ạ", "a").Replace("ã", "a").Replace("ả", "a");
                strValue = strValue.Replace("ắ", "a").Replace("ằ", "a").Replace("ậ", "a").Replace("ẵ", "a").Replace("ẳ", "a").Replace("ă", "a");
                strValue = strValue.Replace("ấ", "a").Replace("ầ", "a").Replace("ậ", "a").Replace("ẫ", "a").Replace("ẩ", "a").Replace("â", "a");

                // - Special with char 'D'
                strValue = strValue.Replace("đ", "d");

                // - Special with char 'E'
                strValue = strValue.Replace("è", "e").Replace("é", "e").Replace("ẹ", "e").Replace("ẽ", "e").Replace("ẻ", "e");
                strValue = strValue.Replace("ề", "e").Replace("ế", "e").Replace("ệ", "e").Replace("ễ", "e").Replace("ể", "e").Replace("ê", "e");

                // - Special with char 'O'
                strValue = strValue.Replace("ò", "o").Replace("ó", "o").Replace("ọ", "o").Replace("õ", "o").Replace("ỏ", "o");
                strValue = strValue.Replace("ồ", "o").Replace("ố", "o").Replace("ộ", "o").Replace("ỗ", "o").Replace("ổ", "o").Replace("ô", "o");
                strValue = strValue.Replace("ờ", "o").Replace("ớ", "o").Replace("ợ", "o").Replace("ỡ", "o").Replace("ở", "o").Replace("ơ", "o");

                // - Special with char 'U'
                strValue = strValue.Replace("ù", "u").Replace("ú", "u").Replace("ụ", "u").Replace("ũ", "u").Replace("ủ", "u");
                strValue = strValue.Replace("ừ", "u").Replace("ứ", "u").Replace("ự", "u").Replace("ữ", "u").Replace("ử", "u").Replace("ư", "u");

                // - Special with char 'i'
                strValue = strValue.Replace("í", "i").Replace("ì", "i").Replace("ị", "i").Replace("ĩ", "i").Replace("ỉ", "i");

                // - Special with char 'y');
                strValue = strValue.Replace("ỳ", "y").Replace("ý", "y").Replace("ỵ", "y").Replace("ỹ", "y").Replace("ỷ", "i");

                strValue = System.Text.RegularExpressions.Regex.Replace(strValue, "[^0-9a-zA-Z]+?", "-").Replace("--", "-");

            }
            // - Return values
            return strValue.Replace(" ", "-");
        }

        public static string ClearText(string Name)
        {
            string strValue = string.Empty;
            if (!string.IsNullOrEmpty(Name))
            {
                strValue = Name.ToLower();
                strValue = System.Text.RegularExpressions.Regex.Replace(strValue, "[^0-9a-zA-Z]+?", "-").Replace("--", "-");

            }
            // - Return values
            return strValue;
        }

        public static string Clear255(string stringSummary)
        {
            if (!string.IsNullOrEmpty(stringSummary))
            {
                if (stringSummary.Length > 255)
                {
                    stringSummary = stringSummary.Substring(0, 255);
                }
                // Get space max of this string
                for (int i = stringSummary.Length - 1; i >= 0; i--)
                {
                    if (stringSummary[i].CompareTo(' ') == 0)
                    {
                        stringSummary = stringSummary.Substring(0, i);
                        break;
                    }
                }
            }

            return stringSummary;
        }


        public static string RemoveHtml(string stringSummary)
        {
            string Summary = "";
            string[] arraySummary = stringSummary.Split(new Char[] { '<' });
            foreach (string s in arraySummary)
            {
                string htmlString = s.Substring(0, s.IndexOf(">") + CountChars(">"));
                if (string.IsNullOrEmpty(htmlString))
                {
                    Summary += " " + s.Trim();
                }
                else
                {
                    Summary += " " + s.Replace(htmlString, string.Empty).Trim();
                }
            }
            return Summary;
        }

        private static int CountChars(string value)
        {
            int result = 0;
            bool lastWasSpace = false;

            foreach (char c in value)
            {
                if (char.IsWhiteSpace(c))
                {
                    if (lastWasSpace == false)
                    {
                        result++;
                    }
                    lastWasSpace = true;
                }
                else
                {
                    result++;
                    lastWasSpace = false;
                }
            }
            return result;
        }
    }
}
