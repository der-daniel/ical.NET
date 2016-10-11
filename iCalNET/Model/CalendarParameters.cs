using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace iCalNET.Model
{
    public class CalendarParameters : Dictionary<string, CalendarParameter>
    {
        private const string ParameterPattern = "(.+?):(.+?)(?=\\r\\n[A-Z]|$)";
        private const RegexOptions ParameteRegexOptions = RegexOptions.Singleline;

        public CalendarParameters(string source)
        {
            MatchCollection parametereMatches = Regex.Matches(source, ParameterPattern, ParameteRegexOptions);
            foreach (Match parametereMatch in parametereMatches)
            {
                string parameterString = parametereMatch.Groups[0].ToString();
                CalendarParameter calendarParameter = new CalendarParameter(parameterString);
                this[calendarParameter.Name] = calendarParameter;
            }
        }
    }
}
