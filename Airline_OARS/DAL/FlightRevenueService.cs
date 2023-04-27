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
    public class FlightRevenueService : IFlightRevenueReport
    {
        private Airline_OARSContext db;
        public FlightRevenueService(Airline_OARSContext db)
        {
            this.db = db;
        }

        public FlightRevenue GetFlightRevenue(int flightNo)
        {
            try
            {
                FlightRevenue flghtrevenue = new FlightRevenue();

                var flightdtl = db.Flights.Find(flightNo);
                if(flightdtl!=null)
                {
                    var total_revenue = db.Reservations.Where(reserv => reserv.FlightNo == flightNo && reserv.TicketStatus=="Confirmed").Sum(reservation => reservation.TotalFare);
                    
                    flghtrevenue.flightNo = flightNo;
                    flghtrevenue.revenue = total_revenue;

                    return flghtrevenue;

                }
                else
                {
                    throw new Exception("Invalid flight No");
                }
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
