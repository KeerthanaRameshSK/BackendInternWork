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
    public class ReservationService : IReservation
    {
        private Airline_OARSContext db;
        public ReservationService(Airline_OARSContext dbb)
        {
            db = dbb;
        }

        public List<ReservationModel> DisplayAllRecords()
        {
            List<Reservation> lst = new List<Reservation>();
            List<ReservationModel> Reservlst=new List<ReservationModel>();
            try
            {
                lst = db.Reservations.ToList();
                foreach(var Rec in lst)
                {
                    ReservationModel r = new ReservationModel();
                    r.Name = Rec.Name;
                    r.AadharNo = Rec.AadharNo;
                    r.FlightNo = Rec.FlightNo;
                    r.NoOfTicket = Rec.NoOfTicket;
                    r.EmailId = Rec.EmailId;
                    r.PhoneNo = Rec.PhoneNo;
                    r.TicketId = Rec.TicketId;
                    r.TotalFare = Rec.TotalFare;
                    Reservlst.Add(r);
                }

                return Reservlst;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<Reservation> ShowAllRecords()
        {
            List<Reservation> Rlst = new List<Reservation>();
            try
            {
                Rlst = db.Reservations.ToList();                
                return Rlst;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public int AddRecord(ReservationModel AddR)
        {
            Reservation r = new Reservation();
            r.Name = AddR.Name;
            r.AadharNo = AddR.AadharNo;
            r.FlightNo = AddR.FlightNo;
            r.NoOfTicket = AddR.NoOfTicket;
            r.EmailId = AddR.EmailId;
            r.PhoneNo = AddR.PhoneNo;
            try
            {
                var flight = db.Flights.Find(r.FlightNo);
                if(flight!=null)
                {                   
                    var count = db.Reservations.Where(r => r.FlightNo == AddR.FlightNo).Count();
                    TicketStatus tckstatus = new TicketStatus();

                    r.TotalFare = (int)(r.NoOfTicket * flight.Fare);

                    if (count <= flight.NoOfSeats)
                    {
                        r.TicketStatus = "Confirmed";
                    }
                    else
                    {
                        r.TicketStatus= "Rejected";
                    }

                    db.Reservations.Add(r);
                    db.SaveChanges();

                    var lst = db.Reservations.ToList();
                    int n = db.Reservations.Count();
                    var tckdtl = lst[n - 1];

                    AddR.TicketId = tckdtl.TicketId;

                    return AddR.TicketId;

                }
                else
                {
                    throw new Exception("Flight Not Found");
                }
                
            }
            catch (Exception e)
            {
                //if (e.InnerException != null)
                //{
                //    throw new Exception(e.InnerException.Message);
                //}
                throw new Exception(e.Message); 
            }
        }

        public float CancelTicket(int ticketId)
        {
            try
            {
                var ticketRec = db.Reservations.Find(ticketId);
                var flight = db.Flights.Find(ticketRec.FlightNo);
                if(ticketRec!=null && flight!=null)
                {
                    float RefundAmount;
                    int cancelhour = DateTime.Now.Hour;
                    int cancelMin = DateTime.Now.Minute;

                    int cancelDay= DateTime.Now.Day;
                    int cancelMonth = DateTime.Now.Month;
                    int cancelYear = DateTime.Now.Year;

                    string boardingTime = flight.DepatureTime;
                    int boardinghour = Convert.ToInt32(boardingTime.Substring(0, 2));
                    int boardingMin = Convert.ToInt32(boardingTime.Substring(3));

                    string boardingDate = flight.Depature.ToString().Substring(0,10);
                    int boardingDay = Convert.ToInt32(boardingDate.Substring(0,2));
                    int boardingMonth = Convert.ToInt32((boardingDate.Substring(0, 5)).Substring(3));
                    int boardingYear = Convert.ToInt32(boardingDate.Substring(6));

                    if(cancelYear>boardingYear)
                    {
                        RefundAmount = 0;
                    }
                    else if(cancelYear<boardingYear)
                    {
                        RefundAmount = (40 * ticketRec.TotalFare) / 100;
                    }
                    else
                    {
                        if(cancelMonth>boardingMonth)
                        {
                            RefundAmount = 0;
                        }
                        else if(cancelMonth < boardingMonth)
                        {
                            RefundAmount = (40 * ticketRec.TotalFare) / 100;
                        }
                        else
                        {
                            if(cancelDay>boardingDay)
                            {
                                RefundAmount = 0;
                            }
                            else if(cancelDay < boardingDay)
                            {
                                RefundAmount = (40 * ticketRec.TotalFare) / 100;
                            }
                            else
                            {
                                if (cancelhour > boardinghour)
                                {
                                    RefundAmount = 0;
                                }
                                else if (cancelhour < boardinghour)
                                {
                                    RefundAmount = (40 * ticketRec.TotalFare) / 100;
                                }
                                else
                                {
                                    if (cancelMin >= boardingMin)
                                    {
                                        RefundAmount = 0;
                                    }
                                    else
                                    {
                                        RefundAmount = (40 * ticketRec.TotalFare) / 100;
                                    }
                                }
                            }
                        }
                    }

                    db.Reservations.Remove(ticketRec);
                    db.SaveChanges();
                  
                    return RefundAmount;
                    
                }
                else
                {
                    throw new Exception("Invalid TicketId");
                }

            }catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
