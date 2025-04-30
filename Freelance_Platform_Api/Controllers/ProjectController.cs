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
            var projects = context.Projects
                .Include(p => p.Client)
                    .ThenInclude(u => u.Role)
                .Include(p => p.Freelancer)
                    .ThenInclude(u => u.Role)
                .ToList();

            return Ok(projects);
        }


        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var project = context.Projects
                .Include(p => p.Client)
                    .ThenInclude(u => u.Role)
                .Include(p => p.Freelancer)
                    .ThenInclude(u => u.Role)
                .FirstOrDefault(p => p.ProjectId == id);

            if (project == null) return NotFound();

            return Ok(project);
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
