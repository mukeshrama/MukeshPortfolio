using System.Collections.Generic;
using MukeshPortfolio.Models;

namespace MukeshPortfolio.Services
{
    public interface IPortfolioService
    {
        Profile GetProfile();
        IEnumerable<Project> GetProjects();
        Project? GetProjectById(int id);
        IEnumerable<WorkExperience> GetWorkExperience();
        IEnumerable<Education> GetEducation();
        string[] GetSkills();
        Dictionary<string, string[]> GetSkillCategories();
    }
}