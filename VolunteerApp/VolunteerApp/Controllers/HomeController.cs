using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using VolunteerApp.Data;
using VolunteerApp.Models;
using VolunteerApp.Services;

namespace VolunteerApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IVolunteerService _volunteerService;
        public HomeController(ILogger<HomeController> logger, IVolunteerService volunteerService)
        {
            _logger = logger;
            _volunteerService = volunteerService;
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
                List<Volunteer> volunteers = _volunteerService.SearchVolunteers(manageVolunteersViewModel.LastName);
                ViewBag.Volunteers = volunteers;
            }
            return View(manageVolunteersViewModel);
        }
        [HttpPost]
        public IActionResult SearchVolunteers(ManageVolunteersViewModel manageVolunteersViewModel)
        {
            TempData["LastName"] = manageVolunteersViewModel.LastName;
            return RedirectToAction("ManageVolunteers");
        }

        private List<SelectListItem> GetStatuses()
        {
            List<SelectListItem> statuses = new List<SelectListItem>()
            {
                new SelectListItem {Text = "--Select--", Value = ""},
                new SelectListItem {Text = "Approved", Value = "Approved"},
                new SelectListItem {Text = "Pending Approval", Value = "Pending Approval"},
                new SelectListItem {Text = "Disapproved", Value = "Disapproved"},
                new SelectListItem {Text = "Inactive", Value = "Inactive"}
            };
            return statuses;

        }

        [HttpGet]
        public IActionResult EditVolunteer(int id)
        {
            Volunteer volunteer = _volunteerService.GetVolunteer(id);
            ViewBag.Statuses = GetStatuses();
            return View(volunteer); 
        }
        [HttpPost]
        public IActionResult EditVolunteer(Volunteer volunteer)
        {
            bool result = _volunteerService.EditVolunteer(volunteer);
            if (result)
            {
                TempData["SuccessMessage"] = "Volunteer Succesfully Updated";
                return RedirectToAction("ManageVolunteers");

            }
            else
            {
                TempData["FailureMessage"] = "Volunteer Unsuccesfully Updated";
                return RedirectToAction("EditVolunteer", new { id = volunteer.ID});
            }

        }




        [HttpGet]
        public IActionResult AddVolunteer()
        {           
            ViewBag.Statuses = GetStatuses();
            return View();
        }
        [HttpPost]
        public IActionResult AddVolunteer(Volunteer volunteer)
        {
            bool result = _volunteerService.AddVolunteer(volunteer);
            if (result)
            {
                TempData["SuccessMessage"] = "Volunteer Succesfully Added";
                return RedirectToAction("ManageVolunteers");

            }
            else
            {
                TempData["FaliureMessage"] = "Volunteer Unsuccesfully Added";
                return RedirectToAction("AddVolunteer");
            }
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