using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace iCalNET.Model
{
    public class CalendarParameter
    {
        private const string NameValuePattern = "(.+?):(.+)";

        public string Name { get; set; }
        public string Value { get; set; }

        public CalendarParameter(string source)
        {
            string unfold = ContentLine.UnfoldAndUnescape(source);
            Match nameValueMatch = Regex.Match(unfold, NameValuePattern);
            Name = nameValueMatch.Groups[1].ToString().Trim();
            Value = nameValueMatch.Groups[2].ToString().Trim();
        }

    }
}
