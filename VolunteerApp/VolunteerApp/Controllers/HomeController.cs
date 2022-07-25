using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VolunteerApp.Models;

namespace VolunteerApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult ManageVolunteers()
        {
            var manageVolunteersViewModel = new ManageVolunteersViewModel();
            if (TempData["LastName"] != null)
            {
                manageVolunteersViewModel.LastName = TempData["LastName"].ToString();
                List<Volunteer> volunteers = SearchVolunteersInDB(manageVolunteersViewModel.LastName);
                ViewBag.Volunteers = volunteers;
            }
            return View(manageVolunteersViewModel);
        }

        private List<Volunteer> SearchVolunteersInDB(string? lastName)
        {
            List<Volunteer> volunteers = new List<Volunteer>();
            volunteers.Add(new Volunteer { FirstName = "Ivan", LastName = "Valdes" });
            volunteers.Add(new Volunteer { FirstName = "md", LastName = "va" });
            volunteers.Add(new Volunteer { FirstName = "mv", LastName = "vl" });
            volunteers.Add(new Volunteer { FirstName = "mc", LastName = "vd" });
            return volunteers;
        }

        [HttpPost]
        public IActionResult SearchVolunteers(ManageVolunteersViewModel manageVolunteersViewModel)
        {
            TempData["LastName"] = manageVolunteersViewModel.LastName;
            return RedirectToAction("ManageVolunteers");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}