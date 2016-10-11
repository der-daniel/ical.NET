using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace iCalNET.Model
{
    public class ContentLine
    {
        private const string ContentLineContentPattern = "(.+?)((;.+?)*):(.+)";
        private const RegexOptions ContentLineContentRegexOptions = RegexOptions.Singleline;

        public string Name { get; set; }
        public string Value { get; set; }
        public ContentLineParameters Parameters { get; set; }

        public ContentLine(string source)
        {
            source = UnfoldAndUnescape(source);
            Match match = Regex.Match(source, ContentLineContentPattern, ContentLineContentRegexOptions);
            // TODO Error Handling
            Name = match.Groups[1].ToString().Trim();
            Parameters = new ContentLineParameters(match.Groups[2].ToString());
            Value = match.Groups[4].ToString().Trim();
        }

        public static string UnfoldAndUnescape(string s)
        {
            string unfold = Regex.Replace(s, "(\\r\\n )", "");
            string unescaped = Regex.Unescape(unfold);
            return unescaped;
        }

    }
}
