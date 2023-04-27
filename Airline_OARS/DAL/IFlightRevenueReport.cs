using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;

namespace DAL
{
    public interface IFlightRevenueReport
    {
        public FlightRevenue GetFlightRevenue(int flightNo);
    }
}
