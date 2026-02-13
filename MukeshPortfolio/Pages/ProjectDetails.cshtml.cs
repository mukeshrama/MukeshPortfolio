using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MukeshPortfolio.Models;
using MukeshPortfolio.Services;

namespace MukeshPortfolio.Pages
{
    public class ProjectDetailsModel : PageModel
    {
        private readonly IPortfolioService _portfolioService;

        public Project Project { get; private set; }

        public ProjectDetailsModel(IPortfolioService portfolioService)
        {
            _portfolioService = portfolioService;
        }

        public IActionResult OnGet(int id)
        {
            var project = _portfolioService.GetProjectById(id);
            if (project == null)
            {
                return NotFound();
            }

            Project = project;
            return Page();
        }
    }
}
