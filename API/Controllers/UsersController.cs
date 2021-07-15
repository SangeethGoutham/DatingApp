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
    public class UsersController : BaseApiController
    {
        private readonly DataContext _context;
        public UsersController(DataContext context)
        {
            _context = context;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers() 
        {
            var users = _context.Users.ToListAsync();

            return await users;
        }

        // api/users/3
        [Authorize]
         [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUsers(int id) 
        {
            return await _context.Users.FindAsync(id);

            
        }
    }
}