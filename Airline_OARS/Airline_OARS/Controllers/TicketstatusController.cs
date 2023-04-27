using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using EntityLayer;
using DAL.Models;
using Microsoft.AspNetCore.Authorization;

namespace UILayer.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    

    public class TicketstatusController : ControllerBase
    {
        private ITicketstatus rserv;

        public TicketstatusController(ITicketstatus rser)
        {
            rserv = rser;
        }


        [HttpGet]
        [Route("ShowByIdTicket/{tckid}")]
        public IActionResult Show(int tckid)
        {
            TicketstatusModel tm = new TicketstatusModel();
            try
            {
                tm = rserv.ShowById(tckid);
                return Ok(tm);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


    }
}
