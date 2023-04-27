using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using EntityLayer;
using DAL.Models;

namespace UILayer.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IUser Uservice;
        public LoginController(IUser Uservice)
        {
            this.Uservice = Uservice;
        }
        [HttpPost("ValidateUser")]
        public IActionResult ValidateUser(UserModel user)
        {
            try
            {
                var userData =  Uservice.GetValidUser(user);
                return Ok(userData);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }


        [HttpPost("RegisterUser")]
        public IActionResult RegisterUser(SignupModel user)
        {
            try
            {              
                var userData =  Uservice.SignUp(user);
                return Ok(user);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
    }
}
