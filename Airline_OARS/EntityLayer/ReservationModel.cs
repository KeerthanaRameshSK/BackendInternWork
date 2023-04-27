using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class ReservationModel
    {
        [JsonIgnore]
        public int TicketId { get; set; }
        public int? FlightNo { get; set; }
        public string Name { get; set; }
        public string AadharNo { get; set; }
        public int NoOfTicket { get; set; }
        public string EmailId { get; set; }
        public string PhoneNo { get; set; }

        [JsonIgnore]
        public float TotalFare { get; set; }
    }
}
