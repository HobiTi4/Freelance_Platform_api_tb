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
    public class ProposalController : ControllerBase
    {
        private FreelanceDbContext context;
        private readonly IMapper mapper;

        public ProposalController(IMapper mapper)
        {
            context = new();
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var proposals = context.Proposals
                .Include(p => p.Freelancer)
                    .ThenInclude(u => u.Role)
                .Include(p => p.Project)
                .ToList();

            return Ok(proposals);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var proposal = context.Proposals
                .Include(p => p.Freelancer)
                    .ThenInclude(u => u.Role)
                .Include(p => p.Project)
                .FirstOrDefault(p => p.ProposalId == id);

            if (proposal == null) return NotFound();

            return Ok(proposal);
        }


        [HttpPost]
        public IActionResult Create(CreateProposalModel model)
        {
            context.Proposals.Add(mapper.Map<Proposal>(model));
            context.SaveChanges();
            return Created();
        }

        [HttpPut]
        public IActionResult Edit(Proposal model)
        {
            context.Proposals.Update(model);
            context.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var item = context.Proposals.Find(id);
            if (item == null) return NotFound();

            context.Proposals.Remove(item);
            context.SaveChanges();

            return NoContent();
        }
    }
}
