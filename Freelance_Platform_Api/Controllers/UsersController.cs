using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DataAccess.Data;
using DataAccess.Entities;
using AutoMapper;
using Freelance_Platform_Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Freelance_Platform_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private FreelanceDbContext context;
        private readonly IMapper mapper;

        public UsersController(IMapper mapper)
        {
            context = new();
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var users = context.Users
                               .Include(u => u.Role)
                               .ToList();
            return Ok(users);
        }


        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var item = context.Users
                              .Include(u => u.Role)
                              .FirstOrDefault(u => u.UserID == id);

            if (item == null) return NotFound();

            return Ok(item);
        }

        [HttpPost]
        public IActionResult Create(CreateUserModel model)
        {
            context.Users.Add(mapper.Map<User>(model));
            context.SaveChanges();
            return Created();
        }

        [HttpPut]
        public IActionResult Edit(User model)
        {
            context.Users.Update(model);
            context.SaveChanges();

            return Ok(); 
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var item = context.Users.Find(id);
            if (item == null) return NotFound();

            context.Users.Remove(item);
            context.SaveChanges();

            return NoContent();
        }
    }
}
