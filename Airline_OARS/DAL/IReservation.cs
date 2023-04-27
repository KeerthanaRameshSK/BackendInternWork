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
    public interface IReservation
    {
        public List<Reservation> ShowAllRecords();
        public int AddRecord(ReservationModel AddR);
        public float CancelTicket(int ticketId);

    }
}
