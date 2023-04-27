using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Models
{
    public partial class Flight
    {
        public Flight()
        {
            Reservations = new HashSet<Reservation>();
        }

        public int FlightNo { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public int? NoOfSeats { get; set; }
        public DateTime? Depature { get; set; }
        public string DepatureTime { get; set; }
        public DateTime? Arrival { get; set; }
        public string ArrivalTime { get; set; }
        public int? Fare { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
