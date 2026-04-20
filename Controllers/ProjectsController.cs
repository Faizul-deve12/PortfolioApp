using Microsoft.AspNetCore.Mvc;
using PortfolioApp.Data;

public class ProjectsController : Controller
{
    private readonly ApplicationDbContext _context;

    public ProjectsController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var projects = _context.Projects.ToList();
        return View(projects);
    }
}



