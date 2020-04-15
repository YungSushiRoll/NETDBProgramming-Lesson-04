using System;
using System.Collections.Generic;
using System.Text;

namespace TicketSystemPt2
{
    public class Ticket
    {
        public int ticketId { get; set; }
        public string summary { get; set; }
        public string status { get; set; }
        public string priority { get; set; }
        public string submitter{ get; set; }
        public string assigned { get; set; }
        public List<string> watchers { get; set; }

        public Ticket()
        {
            watchers = new List<string>();
        }

        public string Output()
        {
            return ticketId + " " + summary + " " + status + " " + priority + " " + submitter + " " + assigned + " " + string.Join("|",watchers);
        }

    }
}
