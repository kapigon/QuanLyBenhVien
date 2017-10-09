using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace QLBV_DEV.Helpers
{
    public partial class ValidateInput
    {
        /// <summary>
        /// Check Validate Email
        /// </summary>
        public static bool IsValidEmailAddress(string EmailAddress)
        {
            Regex regEmail = new Regex(@"^[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");

            if (regEmail.IsMatch(EmailAddress))
                return true;

            return false;
        }

        /// <summary>
        /// Return value are true or false
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static bool IsImage(string fileName)
        {
            if (fileName != null
                && (fileName.ToLower().IndexOf(".jpeg") > -1 || fileName.ToLower().IndexOf(".jpg") > -1 || fileName.ToLower().IndexOf(".gif") > -1 || fileName.ToLower().IndexOf(".png") > -1)
                && (fileName.Length >= 1 && fileName.Length < 200))
            {
                return true;
            }
            return false;
        }
        
        /// <summary>
        /// Clear all character input incorrect.
        /// </summary>
        /// <param name="inputText">return a string input valid</param>
        /// <returns></returns>
        public static string InputText(string inputText)
        {
            return inputText;
        }

        public static bool isBool(string inputText)
        {
            try
            {
                return bool.Parse(inputText);
            }
            catch
            {
                return false;
            }
        }
        public static int isInt(string inputText)
        {
            try
            {
                return int.Parse(inputText);
            }
            catch
            {
                return 0;
            }
        }

        public static decimal isDecimal(string inputText)
        {
            try
            {
                return decimal.Parse(inputText);
            }
            catch
            {
                return 0;
            }
        }
        /// <summary>
        /// Clear all character not allow.
        /// </summary>
        /// <param name="inputText">return a string</param>
        public static string ClearInputText(string inputText)
        {
            if (!string.IsNullOrEmpty(inputText))
            {
                inputText = System.Text.RegularExpressions.Regex.Replace(inputText, "[^0-9a-zA-Z]+?", "");
            }

            return inputText;
        }
    }
}
