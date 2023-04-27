using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class SearchFlightsModel
    {
        public string Origin { get; set; }
        public string Destination { get; set; }
        public DateTime? Depature { get; set; }
    }
}
