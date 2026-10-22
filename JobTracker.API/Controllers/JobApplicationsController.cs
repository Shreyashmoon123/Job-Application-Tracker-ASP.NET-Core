using JobTracker.API.Data;
using JobTracker.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JobTracker.API.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class JobApplicationsController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public JobApplicationsController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JobApplication>>> GetAll()
        {
            return await _applicationDbContext.JobApplications.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<JobApplication>> GetById(int id)
        {
            var application = await _applicationDbContext.JobApplications.FindAsync(id);

            if (application == null)
                return NotFound();

            return application;
        }
        [HttpPost]
        public async Task<ActionResult<JobApplication>> Create(JobApplication application)
        {
            _applicationDbContext.JobApplications.Add(application);
            await _applicationDbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = application.Id }, application);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, JobApplication application)
        {
            if(id != application.Id)
                return BadRequest();

                var existingapplication = await _applicationDbContext.JobApplications.FindAsync(id);

                if (existingapplication == null)
                    return NotFound();

                existingapplication.CompanyName = application.CompanyName;
                existingapplication.JobRole = application.JobRole;
                existingapplication.ApplicationDate = application.ApplicationDate;
                existingapplication.Status = application.Status;

                await _applicationDbContext.SaveChangesAsync();

                return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var Application = await _applicationDbContext.JobApplications.FindAsync(id);

            if(Application == null)
                return NotFound();

            _applicationDbContext.JobApplications.Remove(Application);
            await _applicationDbContext.SaveChangesAsync();

            return NoContent();
        }
    }
}
