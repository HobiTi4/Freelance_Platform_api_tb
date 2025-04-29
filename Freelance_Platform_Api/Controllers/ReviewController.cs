using AutoMapper;
using DataAccess.Data;
using DataAccess.Entities;
using Freelance_Platform_Api.Models;
using Microsoft.AspNetCore.Mvc;

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
            return Ok(context.Reviews.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var item = context.Reviews.Find(id);
            if (item == null) return NotFound();

            return Ok(item);
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
