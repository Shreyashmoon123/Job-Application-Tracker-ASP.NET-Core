using JobTracker.MVC.Models;
using Microsoft.AspNetCore.Mvc;

    namespace JobTracker.MVC.Controllers
{
    public class JobApplicationsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public JobApplicationsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient("JobTrackerAPI");

            var applications = await client.GetFromJsonAsync<List<JobApplication>>(
                "api/JobApplications");

            return View(applications ?? new List<JobApplication>());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(JobApplication application)
        {
            var client = _httpClientFactory.CreateClient("JobTrackerAPI");

            var response = await client.PostAsJsonAsync(
                "api/JobApplications", application);

            if (response.IsSuccessStatusCode)
                return RedirectToAction(nameof(Index));

            ModelState.AddModelError("", "Unable to save job application.");
            return View(application);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var client = _httpClientFactory.CreateClient("JobTrackerAPI");

            var application = await client.GetFromJsonAsync<JobApplication>(
                $"api/JobApplications/{id}");

            if (application == null)
                return NotFound();

            return View(application);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, JobApplication application)
        {
            if (id != application.Id)
                return BadRequest();

            var client = _httpClientFactory.CreateClient("JobTrackerAPI");

            var response = await client.PutAsJsonAsync(
                $"api/JobApplications/{id}", application);

            if (response.IsSuccessStatusCode)
                return RedirectToAction(nameof(Index));

            ModelState.AddModelError("", "Unable to update job application.");
            return View(application);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var client = _httpClientFactory.CreateClient("JobTrackerAPI");

            var response = await client.DeleteAsync(
                $"api/JobApplications/{id}");

            return RedirectToAction(nameof(Index));
        }
    }

   }