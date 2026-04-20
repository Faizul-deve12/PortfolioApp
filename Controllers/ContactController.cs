using Microsoft.AspNetCore.Mvc;
using PortfolioApp.Data;
using PortfolioApp.Models;
using PortfolioApp.Services;

namespace PortfolioApp.Controllers
{
    public class ContactController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly EmailService _emailService;

        public ContactController(ApplicationDbContext context, EmailService emailService)
        {
            _context = context;
            _emailService = emailService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendMessage(ContactMessage message)
        {
            if (ModelState.IsValid)
            {
                _context.ContactMessages.Add(message);
                _context.SaveChanges();

                // Email notification
                _emailService.SendEmailAsync("fazulkhanfazul107@gmail.com", "New Contact Message",
                    $"Name: {message.Name}<br>Email: {message.Email}<br>Message: {message.Message}");

                ViewBag.Success = "Your message has been sent successfully!";
                return View("Index");
            }
            return View("Index", message);
        }
    }
}

