using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace iCal_sync.ical_NET.Model
{
    public class vCalendar
    {
        public List<ContentLine> Properties { get; set; }
        public List<vEvent> vEvents { get; set; }


        public vCalendar(string icsFile)
        {
            Properties = new List<ContentLine>();
            vEvents = new List<vEvent>();
            foreach (Match contentline in
                    Regex.Matches(Regex.Match(icsFile, @"BEGIN:VCALENDAR(.*?)BEGIN:VEVENT", RegexOptions.Singleline).Groups[1].Value, @"(.*?:.*(\n\s.*)*)"))
                Properties.Add(new ContentLine(contentline.Groups[1].Value));
            foreach (Match vevent in Regex.Matches(icsFile, @"BEGIN:VEVENT(.*?)END:VEVENT", RegexOptions.Singleline))
                vEvents.Add(new vEvent(vevent.Groups[1].Value));
        }


        public ContentLine GetProperty(string name)
        {
            return Properties.FirstOrDefault(x => x.Name.Equals(name));
        }
    }
}