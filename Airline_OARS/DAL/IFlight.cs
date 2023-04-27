using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Models;
using EntityLayer;

namespace DAL
{
    public interface IFlight
    {
       
        public List<FlightModel> ShowAllRecords();
        public FlightModel AddRecord(FlightModel AddF);
        public List<FlightModel> GetFlights(SearchFlightsModel searchFlights);
        




    }
}
