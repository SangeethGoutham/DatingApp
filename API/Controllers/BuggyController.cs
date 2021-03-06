using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Interfaces;
using Microsoft.AspNetCore.Authorization;
using System;

namespace API.Controllers
{
    public class BuggyController : BaseApiController
    {
        private readonly DataContext _context;
        
        public BuggyController(DataContext context){
            _context = context;
        }

        [Authorize]
        [HttpGet("auth")]
        public ActionResult<string> GetSecret(){
            
            return "Secret text";
        }

         [HttpGet("not-found")]
        public ActionResult<AppUser> GetNotFound(){
            
           var thing = _context.Users.Find(-1);
           if(thing == null)
           {
               return NotFound();
           }

           return Ok(thing);
        }

        [HttpGet("server-error")]
        public ActionResult<string> GetServerError(){
            
            
            var thing = _context.Users.Find(-1);
           var thingToReturn = thing.ToString();

           return thingToReturn;    
                           
           
        }

         [HttpGet("bad-request")]
        public ActionResult<string> GetBadRequest(){
            
            return BadRequest("This is not a good request");
        }
    }
}