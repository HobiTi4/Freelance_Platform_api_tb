using AutoMapper;
using DataAccess.Data;
using DataAccess.Entities;
using Freelance_Platform_Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Freelance_Platform_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private FreelanceDbContext context;
        private readonly IMapper mapper;

        public ChatController(IMapper mapper)
        {
            context = new();
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var chats = context.Chats
                .Include(c => c.Sender)
                    .ThenInclude(u => u.Role)
                .Include(c => c.Receiver)
                    .ThenInclude(u => u.Role)
                .ToList();
            return Ok(chats);
        }


        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var chat = context.Chats
                .Include(c => c.Sender)
                    .ThenInclude(u => u.Role)
                .Include(c => c.Receiver)
                    .ThenInclude(u => u.Role)
                .FirstOrDefault(c => c.ChatId == id);

            if (chat == null) return NotFound();

            return Ok(chat);
        }


        [HttpPost]
        public IActionResult Create(CreateChatModel model)
        {
            context.Chats.Add(mapper.Map<Chat>(model));
            context.SaveChanges();
            return Created();
        }

        [HttpPut]
        public IActionResult Edit(Chat model)
        {
            context.Chats.Update(model);
            context.SaveChanges();

            return Ok();
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var item = context.Chats.Find(id);
            if (item == null) return NotFound();

            context.Chats.Remove(item);
            context.SaveChanges();

            return NoContent();
        }
    }
}
