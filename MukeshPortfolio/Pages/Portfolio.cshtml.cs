using Microsoft.AspNetCore.Mvc.RazorPages;
using MukeshPortfolio.Models;
using MukeshPortfolio.Services;

namespace MukeshPortfolio.Pages
{
    public class PortfolioModel : PageModel
    {
        private readonly IPortfolioService _portfolioService;

        public Profile Profile { get; private set; }
        public IEnumerable<Project> Projects { get; private set; }

        public PortfolioModel(IPortfolioService portfolioService)
        {
            _portfolioService = portfolioService;
        }

        public void OnGet()
        {
            Profile = _portfolioService.GetProfile();
            Projects = _portfolioService.GetProjects();
        }
    }
}
