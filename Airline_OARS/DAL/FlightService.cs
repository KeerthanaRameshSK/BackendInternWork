using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Models;
using EntityLayer;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class FlightService : IFlight
    {
        private Airline_OARSContext db;

        public FlightService(Airline_OARSContext dbb)
        {
            db = dbb;
        }

        public List<FlightModel> ShowAllRecords()
        {
            List<FlightModel> lst = new List<FlightModel>();
            List<Flight> Rlst = new List<Flight>();
            try
            {
                Rlst = db.Flights.ToList();
                foreach (var r in Rlst)
                {
                    FlightModel fm = new FlightModel();
                    fm.FlightNo = r.FlightNo;
                    fm.Origin = r.Origin;
                    fm.Destination = r.Destination;
                    fm.Depature = r.Depature;
                    fm.Arrival = r.Arrival;
                    fm.NoOfSeats = r.NoOfSeats;
                    fm.Fare = r.Fare;
                    fm.ArrivalTime = r.ArrivalTime;
                    fm.DepatureTime = r.DepatureTime;
                    lst.Add(fm);
                }
                return lst;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public FlightModel AddRecord(FlightModel AddF)
        {
            Flight f = new Flight();
            f.FlightNo = AddF.FlightNo;
            f.Origin = AddF.Origin;
            f.Destination = AddF.Destination;
            f.Depature = AddF.Depature;
            f.Arrival = AddF.Arrival;
            f.NoOfSeats = AddF.NoOfSeats;
            f.Fare = AddF.Fare;
            f.ArrivalTime = AddF.ArrivalTime;
            f.DepatureTime = AddF.DepatureTime;
            try
            {
                if (AddF != null)
                {
                    db.Flights.Add(f);
                    db.SaveChanges();
                    return AddF;
                }
                else
                {
                    throw new Exception("Invalid flight details");
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<FlightModel> GetFlights(SearchFlightsModel searchFlights)
        {
            try
            {
                List<FlightModel> flightslst = new List<FlightModel>();

                var flightDtls = db.Flights.Where(flight => flight.Origin == searchFlights.Origin && flight.Destination == searchFlights.Destination && flight.Depature == searchFlights.Depature).Select(flight => flight);

                if (flightDtls != null)
                {
                    foreach (var flightRec in flightDtls)
                    {
                        FlightModel flight = new FlightModel();
                        flight.FlightNo = flightRec.FlightNo;
                        flight.Origin = flightRec.Origin;
                        flight.Destination = flightRec.Destination;
                        flight.Depature = flightRec.Depature;
                        flight.Arrival = flightRec.Arrival;
                        flight.NoOfSeats = flightRec.NoOfSeats;
                        flight.Fare = flightRec.Fare;
                        flight.ArrivalTime = flightRec.ArrivalTime;
                        flight.DepatureTime = flightRec.DepatureTime;

                        flightslst.Add(flight);
                    }

                    return flightslst;
                }
                else
                {
                    throw new Exception("No flights found");
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    

        
    }
}

    




       
