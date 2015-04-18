using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace iCal_sync.ical_NET.Model
{
    public class vEvent
    {
        public List<ContentLine> ContentLines { get; set; }

        public vEvent(string vevent)
        {
            ContentLines = new List<ContentLine>();
            foreach (Match contentline in Regex.Matches(vevent, @"(.*?:.*(\n\s.*)*)"))
                ContentLines.Add(new ContentLine(contentline.Groups[1].Value));
        }
    }
}
