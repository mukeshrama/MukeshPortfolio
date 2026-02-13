using Microsoft.AspNetCore.Mvc;
using MukeshPortfolio.Models;
using MukeshPortfolio.Services;

namespace MukeshPortfolio.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPortfolioService _portfolioService;

        public HomeController(IPortfolioService portfolioService)
        {
            _portfolioService = portfolioService;
        }

        public IActionResult Index()
        {
            var vm = new HomeIndexViewModel
            {
                Profile = _portfolioService.GetProfile(),
                Projects = _portfolioService.GetProjects()
            };
            return View(vm);
        }

        public IActionResult About()
        {
            var vm = new AboutViewModel
            {
                Profile = _portfolioService.GetProfile(),
                WorkExperience = _portfolioService.GetWorkExperience(),
                Education = _portfolioService.GetEducation(),
                Skills = _portfolioService.GetSkills()
            };
            return View(vm);
        }

        public IActionResult Skills()
        {
            var vm = new SkillsViewModel
            {
                Skills = _portfolioService.GetSkills(),
                SkillCategories = _portfolioService.GetSkillCategories()
            };
            return View(vm);
        }

        public IActionResult Education()
        {
            var vm = new EducationViewModel
            {
                Education = _portfolioService.GetEducation()
            };
            return View(vm);
        }

        public IActionResult Contact()
        {
            var profile = _portfolioService.GetProfile();
            return View(profile);
        }

        public IActionResult Details(int id)
        {
            var project = _portfolioService.GetProjectById(id);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore =   true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = System.Diagnostics.Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
