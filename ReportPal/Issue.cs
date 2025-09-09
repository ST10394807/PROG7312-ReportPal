using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportPal
{
    public class Issue
    {
        public string Reporter { get; set; }
        public string Email { get; set; }
        public string Suburb { get; set; }
        public string Location { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public List<string> Attachments { get; set; }
    }
}
