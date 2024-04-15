using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UFOrganizer
{
    public class ListObject : IUfoReportListViewObject
    {
        // Properties
        public string City { get; set; }
        public DateTime DateTime { get; set; }
        public string Summary { get; set; }

        // ctor
        public ListObject(string city, DateTime date, string summary)
        {
            City = city;
            DateTime = date;
            Summary = summary;
        }
    }
}
