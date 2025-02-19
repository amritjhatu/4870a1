using Code1stUsersRoles.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

public class HomeController : Controller
{
    private readonly ApplicationDbContext _context;

    public HomeController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var articles = _context.Articles.Where(a => a.StartDate <= DateTime.Now && a.EndDate >= DateTime.Now).ToList();
        return View(articles);
    }
}