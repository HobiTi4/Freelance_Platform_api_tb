using AutoMapper;
using DataAccess.Data;
using DataAccess.Entities;
using Freelance_Platform_Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Freelance_Platform_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private FreelanceDbContext context;
        private readonly IMapper mapper;

        public TransactionController(IMapper mapper)
        {
            context = new();
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(context.Transactions.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var item = context.Transactions.Find(id);
            if (item == null) return NotFound();

            return Ok(item);
        }

        [HttpPost]
        public IActionResult Create(CreateTransactionModel model)
        {
            context.Transactions.Add(mapper.Map<Transaction>(model));
            context.SaveChanges();
            return Created();
        }

        [HttpPut]
        public IActionResult Edit(Transaction model)
        {
            context.Transactions.Update(model);
            context.SaveChanges();

            return Ok();
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var item = context.Transactions.Find(id);
            if (item == null) return NotFound();

            context.Transactions.Remove(item);
            context.SaveChanges();

            return NoContent();
        }

    }
}