using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using EntityLayer;
using Microsoft.AspNetCore.Authorization;
using DAL.Models;

namespace UILayer.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
   
    public class FlightController : ControllerBase
    {
        private IFlight fserv;

        public FlightController(IFlight fser)
        {
            fserv = fser;
        }

        [HttpGet]
        [Route("ShowAll")]
        public IActionResult Display()
        {
            List<FlightModel> fm = new List<FlightModel>();
            try
            {
                fm = fserv.ShowAllRecords();
                return Ok(fm);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Route("GetFlights")]
        public IActionResult GetFlights(SearchFlightsModel searchFlights)
        {
            List<FlightModel> fm = new List<FlightModel>();
            try
            {
                fm = fserv.GetFlights(searchFlights);
                return Ok(fm);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Route("AddFlight")]
        public IActionResult Add(FlightModel rec)
        {
            FlightModel fm = new FlightModel();
            try
            {
                fm =  fserv.AddRecord(rec);
                return Ok(fm);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}


