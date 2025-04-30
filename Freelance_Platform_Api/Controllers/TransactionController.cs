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
            var transactions = context.Transactions
                .Include(t => t.User)
                    .ThenInclude(u => u.Role)
                .ToList();

            return Ok(transactions);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var transaction = context.Transactions
                .Include(t => t.User)
                    .ThenInclude(u => u.Role)
                .FirstOrDefault(t => t.TransactionId == id);

            if (transaction == null)
                return NotFound();

            return Ok(transaction);
        }

        [HttpPost]
        public IActionResult Create(CreateTransactionModel model)
        {
            context.Transactions.Add(mapper.Map<Transaction>(model));
            context.SaveChanges();
            return Created();
        }
    }
}