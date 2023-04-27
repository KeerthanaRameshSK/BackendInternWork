using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Models
{
    public partial class Reservation
    {
        public int TicketId { get; set; }
        public int? FlightNo { get; set; }
        public string Name { get; set; }
        public string AadharNo { get; set; }
        public int NoOfTicket { get; set; }
        public string EmailId { get; set; }
        public string PhoneNo { get; set; }
        public int TotalFare { get; set; }
        public string TicketStatus { get; set; }

        public virtual Flight FlightNoNavigation { get; set; }
    }
}
