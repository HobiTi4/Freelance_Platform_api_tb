using AutoMapper;
using DataAccess.Data;
using DataAccess.Entities;
using Freelance_Platform_Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Freelance_Platform_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private FreelanceDbContext context;
        private readonly IMapper mapper;

        public ProjectController(IMapper mapper)
        {
            context = new();
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(context.Projects.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var item = context.Projects.Find(id);
            if (item == null) return NotFound();

            return Ok(item);
        }

        [HttpPost]
        public IActionResult Create(CreateProjectModel model)
        {
            context.Projects.Add(mapper.Map<Project>(model));
            context.SaveChanges();
            return Created();
        }

        [HttpPut]
        public IActionResult Edit(Project model)
        {
            context.Projects.Update(model);
            context.SaveChanges();

            return Ok();
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var item = context.Projects.Find(id);
            if (item == null) return NotFound();

            context.Projects.Remove(item);
            context.SaveChanges();

            return NoContent();
        }
    }
}
