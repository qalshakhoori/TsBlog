using System;

namespace TsBlog.Core
{
    public static class StringHelper
    {
        #region
        /// <summary>
        /// Intercept a string of specified length
        /// </summary>
        /// <param name="str">original string </param>
        /// <param name="strLength">The length of the string to be retained </param>
        /// <returns></returns>
        public static string CutStrLength(this string str, int strLength)
        {
            var strNew = str;
            if (string.IsNullOrEmpty(strNew)) return strNew;
            var strOriginalLength = strNew.Length;
            if (strOriginalLength > strLength)
            {
                strNew = strNew.Substring(0, strLength) + "...";
            }
            return strNew;
        }

        #endregion

        #region
        /// <summary>
        /// Intercept a string of specified length
        /// </summary>
        /// <param name="str">original string </param>
        /// <param name="strLength">The length of the string to be retained </param>
        /// <param name="endWithEllipsis">is or ends with an ellipsis (...)</param>
        /// <returns></returns>
        public static string CutStrLength(string str, int strLength, bool endWithEllipsis)
        {
            string strNew = str;
            if (!strNew.Equals(""))
            {
                int strOriginalLength = strNew.Length;
                if (strOriginalLength > strLength)
                {
                    strNew = strNew.Substring(0, strLength);
                    if (endWithEllipsis)
                    {
                        strNew += "...";
                    }
                }
            }
            return strNew;
        }

        #endregion

        # region truncation string (complete words can be retained)
        /// <summary>
        /// Truncate strings (complete words can be retained)
        /// </summary>
        /// <param name="valueToTruncate">String to be processed </param>
        /// <param name="maxLength">number of characters </param>
        /// <param name="options">truncation option </param>
        /// <returns></returns>
        public static string TruncateString(this string valueToTruncate, int maxLength, TruncateOptions options)
        {
            if (valueToTruncate == null)
            {
                return "";
            }

            if (valueToTruncate.Length <= maxLength)
            {
                return valueToTruncate;
            }

            var includeEllipsis = (options & TruncateOptions.IncludeEllipsis) ==
                    TruncateOptions.IncludeEllipsis;
            var finishWord = (options & TruncateOptions.FinishWord) ==
                    TruncateOptions.FinishWord;
            var allowLastWordOverflow =
              (options & TruncateOptions.AllowLastWordToGoOverMaxLength) ==
              TruncateOptions.AllowLastWordToGoOverMaxLength;

            var retValue = valueToTruncate;

            if (includeEllipsis)
            {
                maxLength -= 1;
            }

            var lastSpaceIndex = retValue.LastIndexOf(" ",
              maxLength, StringComparison.CurrentCultureIgnoreCase);

            if (!finishWord)
            {
                retValue = retValue.Remove(maxLength);
            }
            else if (allowLastWordOverflow)
            {
                var spaceIndex = retValue.IndexOf(" ",
                  maxLength, StringComparison.CurrentCultureIgnoreCase);
                if (spaceIndex != -1)
                {
                    retValue = retValue.Remove(spaceIndex);
                }
            }
            else if (lastSpaceIndex > -1)
            {
                retValue = retValue.Remove(lastSpaceIndex);
            }

            if (includeEllipsis && retValue.Length < valueToTruncate.Length)
            {
                retValue += "...";
            }
            return retValue;
        }

        #endregion
    }

#region Enumeration for region truncation strings
    /// <summary>
    /// Enumeration for truncating strings
    /// </summary>
    [Flags]
    public enum TruncateOptions
    {
        /// <summary>
        /// No treatment
        /// </summary>
        None = 0x0,
        /// <summary>
        /// Keep the whole word
        /// </summary>
        FinishWord = 0x1,
        /// <summary>
        /// Allow the last word to exceed the maximum length limit
        /// </summary>
        AllowLastWordToGoOverMaxLength = 0x2,
        /// <summary>
        /// String ends with Ellipsis
        /// </summary>
        IncludeEllipsis = 0x4
    }
#endregion
}