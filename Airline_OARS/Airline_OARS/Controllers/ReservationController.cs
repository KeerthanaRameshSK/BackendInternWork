using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using EntityLayer;
using Microsoft.AspNetCore.Authorization;

namespace UILayer.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]

    public class ReservationController : ControllerBase
    {
        private IReservation rserv;

        public ReservationController(IReservation rser)
        {
            rserv = rser;
        }

        [HttpGet]
        [Route("DisplayAll")]
        public IActionResult Display()
        {           
            try
            {
                var rm = rserv.ShowAllRecords();
                return Ok(rm);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Route("Add")]
        public IActionResult Add(ReservationModel rec)
        {           
            try
            {
                var rm = rserv.AddRecord(rec);
                return Ok(rm);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        [Route("CancelTicket/{ticketId}")]
        public IActionResult CancelTicket(int ticketId)
        {
            try
            {
                var RefundAmount = rserv.CancelTicket(ticketId);
                return Ok(RefundAmount);

            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}