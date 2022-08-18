using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class UsersController :  BaseApiController
    {
        private readonly DataContext _context;
        public UsersController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
             return await _context.Users.ToListAsync();
            
        }
[Authorize]
        //api/users/id
        [HttpGet("{id}")]
        public ActionResult<AppUser> GetUser(int id)
        {
           return  _context.Users.Find(id);
           
        }

    }
}