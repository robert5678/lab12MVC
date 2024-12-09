using Microsoft.AspNetCore.Mvc;
using lab12MVC.Data;
using lab12MVC.Models;

namespace lab12MVC.Controllers
{
    public class CompanyController : Controller
    {
        private readonly AppDbContext _context;

        public CompanyController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var companies = _context.Companies.ToList();
            return View(companies);
        }
    }
}
