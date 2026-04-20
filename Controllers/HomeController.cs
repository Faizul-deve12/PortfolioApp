using Microsoft.AspNetCore.Mvc;
using PortfolioApp.Data;
using PortfolioApp.Models;
using System.Diagnostics;

namespace PortfolioApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context; // DbContext add करें

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            // Database से पहला user record लाएँ
            var user = _context.Users.FirstOrDefault();

            // अगर record नहीं है तो dummy data दें
            if (user == null)
            {
                user = new User
                {
                    FullName = "Faizul Faizul",
                    Email = "fazzu5530@gamail.com",
                    Phone = "+91-74649 5XXX",
                    Location = "Delhi, India",
                    ProfileSummary = "I am a fresher .NET Developer with good knowledge of C#, ASP.NET Core MVC, and SQL Server. \r\nI have built projects using CRUD operations and Web APIs, and I am eager to start my career and improve my skills in a real-world environment.."
                };
            }

            return View(user); // Model को View में भेजें
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

