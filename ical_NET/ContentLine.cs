using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace iCal_sync.ical_NET.Model
{
    public class ContentLine
    {

        public string Name { get; set; }
        public string Value { get; set; }
        public Dictionary<string, List<string>> Parameters { get; set; }

        public ContentLine(string contentline)
        {
            contentline = contentline.Trim();
            Name = Regex.Match(contentline, @"(.*?)[;:]").Groups[1].Value;
            Value = Regex.Match(contentline, @".*?:(.*(\n\s.*)*)").Groups[1].Value;
            Parameters = new Dictionary<string, List<string>>();
            foreach (Match paramValue in Regex.Matches(contentline, @"^.*?;(.*:)"))
                foreach (Match paramValueSplit in Regex.Matches(paramValue.Groups[1].Value, @"(.+?)=(.+?)[;:]"))
                    Parameters.Add(paramValueSplit.Groups[1].Value, paramValueSplit.Groups[2].Value.Split(',').ToList());
        }


        public bool HasParameterAndValue(string name, string value)
        {
            try
            {
                return Parameters[name].Contains(value);
            }
            catch (KeyNotFoundException)
            {
                return false;
            }
        }

        public string GetFormattedValue()
        {
            return Regex    .Replace(Value.Replace(Environment.NewLine + "\t", "").Replace(Environment.NewLine + " ", "")
                            .Replace(@"\n\r", Environment.NewLine)
                            .Replace(@"\n", Environment.NewLine)
                            .Replace(@"\r", Environment.NewLine), @"\\(.)", "$1")
                            .Trim();
        }
    }
}