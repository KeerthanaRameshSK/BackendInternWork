using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using DAL.Models;
using EntityLayer;
namespace UILayer.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class FlightReportController : ControllerBase
    {
        private IFlightRevenueReport revenueserv;
        public FlightReportController(IFlightRevenueReport revenueserv)
        {
            this.revenueserv = revenueserv;
        }

        [HttpGet]
        [Route("GetFlightRevenue/{flightNo}")]
        public IActionResult getFlightRevenue(int flightNo)
        {
            try
            {
                var revenue = revenueserv.GetFlightRevenue(flightNo);
                return Ok(revenue);

            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }

        }

    }
}
