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
    public class ReviewController : ControllerBase
    {
        private FreelanceDbContext context;
        private readonly IMapper mapper;

        public ReviewController(IMapper mapper)
        {
            context = new();
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var reviews = context.Reviews
                .Include(r => r.Sender)
                    .ThenInclude(u => u.Role)
                .Include(r => r.Receiver)
                    .ThenInclude(u => u.Role)
                .ToList();

            return Ok(reviews);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var review = context.Reviews
                .Include(r => r.Sender)
                    .ThenInclude(u => u.Role)
                .Include(r => r.Receiver)
                    .ThenInclude(u => u.Role)
                .FirstOrDefault(r => r.ReviewId == id);

            if (review == null)
                return NotFound();

            return Ok(review);
        }

        [HttpPost]
        public IActionResult Create(CreateReviewModel model)
        {
            context.Reviews.Add(mapper.Map<Review>(model));
            context.SaveChanges();
            return Created();
        }

        [HttpPut]
        public IActionResult Edit(Review model)
        {
            context.Reviews.Update(model);
            context.SaveChanges();

            return Ok();
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var item = context.Reviews.Find(id);
            if (item == null) return NotFound();

            context.Reviews.Remove(item);
            context.SaveChanges();

            return NoContent();
        }
    }
}
