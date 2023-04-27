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
    public class TicketstatusService : ITicketstatus
    {
        private Airline_OARSContext db;
        public TicketstatusService(Airline_OARSContext dbb)
        {
            db = dbb;
        }

        public TicketstatusModel ShowById(int tckid)
        {

            var r =  db.Reservations.Find(tckid);

            try
            {
                if(r!=null)
                {
                    TicketstatusModel ts = new TicketstatusModel();
                    ts.TicketId = r.TicketId;
                    ts.Status = r.TicketStatus;
                    return ts;  
                }
                else
                {
                    throw new Exception("Seats not available");
                }
                
            }
            catch (Exception e)
            { throw new Exception(e.Message); }
        }

        
    }
}
