using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace iCalNET.Model
{
    public class vEvent
    {
        private const string vEventContentPattern = "BEGIN:VEVENT\\r\\n(.+)\\r\\nEND:VEVENT";
        private const RegexOptions vEventContentRegexOptions = RegexOptions.Singleline;
        private const string ContentLinePattern = "(.+?):(.+?)(?=\\r\\n[A-Z]|$)";
        private const RegexOptions ContentLineTRegexOptions = RegexOptions.Singleline;

        public Dictionary<string, List<ContentLine>> ContentLines { get; set; }

        public vEvent(string source)
        {
            Match contentMatch = Regex.Match(source, vEventContentPattern, vEventContentRegexOptions);
            string content = contentMatch.Groups[1].ToString();
            MatchCollection matches = Regex.Matches(content, ContentLinePattern, ContentLineTRegexOptions);
            ContentLines = new Dictionary<string, List<ContentLine>>();
            foreach (Match match in matches)
            {
                string contentLineString = match.Groups[0].ToString();
                ContentLine contentLine = new ContentLine(contentLineString);
                if (ContentLines.ContainsKey(ContentLine.name)) 
                {
                    ContentLines[contentLine.Name].Add(contentLine);
                    d[i.ToString()].Add(i.ToString());
                }
                else
                {
                    ContentLines.Add(contentLine.name, new List<ContentLine>() 
                        {
                            contentLine
                        }   
                    );
                }
            }

        }

    }
}
