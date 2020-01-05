using System.Text.RegularExpressions;

namespace TsBlog.Core
{
    public static class HtmlHelper
    {
        #region removes all tags from HTML, leaving only plain text.

        /// <summary>
        /// Remove all tags from HTML and leave only plain text
        /// </summary>
        /// <param name="strHtml"></param>
        /// <returns></returns>
        public static string CleanHtml(this string strHtml)
        {
            if (string.IsNullOrEmpty(strHtml)) return strHtml;
            // Delete scripts
            strHtml = Regex.Replace(strHtml, @"(\<script(.+?)\</script\>)|(\<style(.+?)\</style\>)", "", RegexOptions.IgnoreCase | RegexOptions.Singleline);
            // Delete labels
            var r = new Regex(@"<\/?[^>]*>", RegexOptions.IgnoreCase);
            Match m;
            for (m = r.Match(strHtml); m.Success; m = m.NextMatch())
            {
                strHtml = strHtml.Replace(m.Groups[0].ToString(), "");
            }
            return strHtml.Trim();
        }

        #endregion removes all tags from HTML, leaving only plain text.
    }
}