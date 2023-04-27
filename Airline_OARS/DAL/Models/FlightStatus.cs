using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Models
{
    public partial class FlightStatus
    {
        public int FlightNo { get; set; }
        public string Start { get; set; }
        public string Via { get; set; }
        public string Destination { get; set; }
        public int? TerminalNo { get; set; }
    }
}
