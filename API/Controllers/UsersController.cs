using System.Collections.Generic;
using System.Linq;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers
{
    [Authorize]
    public class UsersController : BaseApiController
    {
        private readonly DataContext _context;
        public UsersController(DataContext context)
        {
            _context = context;
        }

        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers() 
        {
            var users = _context.Users.ToListAsync();

            return await users;
        }

        // api/users/3
        
         [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUsers(int id) 
        {
            return await _context.Users.FindAsync(id);

            
        }
    }
}