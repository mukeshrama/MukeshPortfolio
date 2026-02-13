using System;
using System.Collections.Generic;
using System.Linq;
using MukeshPortfolio.Models;

namespace MukeshPortfolio.Services
{
    public class InMemoryPortfolioService : IPortfolioService
    {
        private readonly Profile _profile;
        private readonly List<Project> _projects;
        private readonly List<WorkExperience> _workExperience;
        private readonly List<Education> _education;
        private readonly string[] _skills;

        public InMemoryPortfolioService()
        {
            _profile = new Profile
            {
                Name = "Mukesh Thakur",
                Role = "Full Stack .NET Developer",
                Summary = "Full Stack .NET Developer with 3+ years of experience in designing, developing, and maintaining enterprise-grade web and desktop applications using C#, ASP.NET, ASP.NET Core, and SQL Server. Strong expertise in REST API development, database design, performance optimization, IIS deployment, Windows application development, and production support.",
                Email = "mukeshraman1999@gmail.com",
                Phone = "+91 7391916147",
                Location = "Mumbai, India",
                LinkedInUrl = "https://linkedin.com/in/mukesh-thakur-601040196",
                GithubUrl = "https://github.com/mukeshrama"
            };

            _projects = new List<Project>
            {
                new Project
                {
                    Id = 1,
                    Title = "Portfolio Website",
                    Description = "Personal portfolio built with ASP.NET Core Razor Pages.",
                    ImageUrl = "/images/portfolio.png",
                    RepoUrl = "https://github.com/your-github/portfolio",
                    LiveUrl = "https://your-portfolio.example.com",
                    Tags = new[] { "ASP.NET Core", "Razor Pages", "C#" },
                    CreatedAt = new DateTime(2024, 1, 10)
                },
                new Project
                {
                    Id = 2,
                    Title = "API Project",
                    Description = "REST API built with ASP.NET Core.",
                    ImageUrl = "/images/api.png",
                    RepoUrl = "https://github.com/your-github/api",
                    LiveUrl = null,
                    Tags = new[] { "API", "ASP.NET Core", "C#" },
                    CreatedAt = new DateTime(2023, 10, 5)
                }
            };

            _workExperience = new List<WorkExperience>
            {
                new WorkExperience
                {
                    Id = 1,
                    Company = "Datamatics Global Services Pvt.Ltd",
                    Position = "Associate Consultant",
                    StartDate = new DateTime(2023, 02, 01),
                    EndDate = null, // Current role
                    Location = "Andheri,Mumbai, India",
                    Responsibilities = new[]
                    {
                        "Designed and developed enterprise-grade web applications using ASP.NET Core and C#",
                        "Built RESTful APIs for internal and external integrations",
                        "Worked on Windows-based desktop applications for backend processing and automation tasks",
                        "Optimized database queries and improved application performance by 40%",
                        "Developed and optimized complex SQL queries and Stored Procedures for improved system performance",
                        "Implemented SAP RFC integration within Windows applications to fetch and process data from SAP systems",
                        "Implemented multiple client Change Requests involving backend logic, UI updates, and database schema changes",
                        "Configured and deployed applications on IIS and handled production releases",
                        "Handled production support, root cause analysis, and project migration activities across environments",
                        "Performed code check-ins and version control management using TFS and SVN"
                    },
                    Technologies = new[] { "C#", "ASP.NET Core", "ASP.NET MVC", "SQL Server", "Stored Procedures", "REST API", "Entity Framework", "WinForms", "SAP RFC", "IIS", "TFS", "SVN" }
                },
                new WorkExperience
                {
                    Id = 2,
                    Company = "TCS Company",
                    Position = "Young Graduate",
                    StartDate = new DateTime(2021, 1, 1),
                    EndDate = new DateTime(2022, 5, 31),
                    Location = "Mumbai, India",
                    Responsibilities = new[]
                    {
                        "Developed and maintained Windows applications using C# and WinForms",
                        "Created REST APIs using ASP.NET Web API",
                        "Worked on database design and optimization with SQL Server",
                        "Provided production support and resolved critical issues",
                        "Collaborated with cross-functional teams for feature development"
                    },
                    Technologies = new[] { "C#", "ASP.NET Web API", "WinForms", "SQL Server", "T-SQL", "IIS", "ADO.NET" }
                }
            };

            _education = new List<Education>
            {
                new Education
                {
                    Id = 1,
                    Degree = "Bachelor of Science (B.S.C CS)",
                    Specialization = "Computer Science",
                    Institution = "KC College - Mumbai University",
                    Location = "Mumbai, India",
                    StartDate = new DateTime(2017, 7, 1),
                    EndDate = new DateTime(2021, 6, 30),
                    Grade = "9.28/10" // or CGPA/Percentage
                },
                new Education
                {
                    Id = 2,
                    Degree = "Higher Secondary Certificate (HSC)",
                    Specialization = "Science",
                    Institution = "Vidhaya Varidhi Junior College",
                    Location = "Mumbai, India",
                    StartDate = new DateTime(2015, 6, 1),
                    EndDate = new DateTime(2017, 5, 31),
                    Grade = "75.60%" // or your actual percentage
                }
            };

            _skills = new[]
            {
                // Backend Technologies
                "C#", "ASP.NET Core", "ASP.NET MVC", "ASP.NET Web API", ".NET Framework",

                // Database & ORM
                "SQL Server", "T-SQL", "Stored Procedures", "Entity Framework", "LINQ", "ADO.NET",

                // Frontend Technologies
                "HTML5", "CSS3", "JavaScript", "jQuery", "Bootstrap", "Razor Pages", "Razor Syntax",

                // APIs & Integration
                "REST API", "RESTful Services", "Web Services", "SAP RFC Integration", "JSON", "XML",

                // Windows Development
                "WinForms", "Windows Services", "Windows Applications", "Desktop Applications",

                // DevOps & Tools
                "Git", "TFS", "SVN", "Azure DevOps", "IIS", "Visual Studio",

                // Architecture & Patterns
                "MVC Pattern", "Dependency Injection", "Repository Pattern", "N-Tier Architecture",

                // Testing & Quality
                "Unit Testing", "Debugging", "Performance Optimization", "Code Review",

                // Soft Skills & Methodologies
                "Agile", "Problem Solving", "Production Support", "Root Cause Analysis", "Change Management"
            };
        }

        public Profile GetProfile() => _profile;

        public IEnumerable<Project> GetProjects() =>
            _projects.OrderByDescending(p => p.CreatedAt);

        public Project? GetProjectById(int id) =>
            _projects.FirstOrDefault(p => p.Id == id);

        public IEnumerable<WorkExperience> GetWorkExperience() =>
            _workExperience.OrderByDescending(w => w.StartDate);

        public IEnumerable<Education> GetEducation() =>
            _education.OrderByDescending(e => e.StartDate);

        public string[] GetSkills() => _skills;

        public Dictionary<string, string[]> GetSkillCategories()
        {
            return new Dictionary<string, string[]>
            {
                ["Backend Technologies"] = new[] { "C#", "ASP.NET Core", "ASP.NET MVC", "ASP.NET Web API", ".NET Framework" },
                ["Database & ORM"] = new[] { "SQL Server", "T-SQL", "Stored Procedures", "Entity Framework", "LINQ", "ADO.NET" },
                ["Frontend Technologies"] = new[] { "HTML5", "CSS3", "JavaScript", "jQuery", "Bootstrap", "Razor Pages", "Razor Syntax" },
                ["APIs & Integration"] = new[] { "REST API", "RESTful Services", "Web Services", "SAP RFC Integration", "JSON", "XML" },
                ["Windows Development"] = new[] { "WinForms", "Windows Services", "Windows Applications", "Desktop Applications" },
                ["DevOps & Tools"] = new[] { "Git", "TFS", "SVN", "Azure DevOps", "IIS", "Visual Studio" },
                ["Architecture & Patterns"] = new[] { "MVC Pattern", "Dependency Injection", "Repository Pattern", "N-Tier Architecture" },
                ["Testing & Quality"] = new[] { "Unit Testing", "Debugging", "Performance Optimization", "Code Review" },
                ["Soft Skills & Methodologies"] = new[] { "Agile", "Problem Solving", "Production Support", "Root Cause Analysis", "Change Management" }
            };
        }
    }
}