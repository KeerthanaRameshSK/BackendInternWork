using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class FlightModel
    {
        public int FlightNo { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public int? NoOfSeats { get; set; }
        public DateTime? Depature { get; set; }
        public DateTime? Arrival { get; set; }

        public string DepatureTime { get; set; }
        public string ArrivalTime { get; set; }
        public int? Fare { get; set; }
    }
}
