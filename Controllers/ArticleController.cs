using Code1stUsersRoles.Data;
using Code1stUsersRoles.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

[Authorize]
public class ArticleController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<CustomUser> _userManager;

    public ArticleController(ApplicationDbContext context, UserManager<CustomUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    public IActionResult Index()
    {
        var articles = _context.Articles.Where(a => a.StartDate <= DateTime.Now && a.EndDate >= DateTime.Now).ToList();
        return View(articles);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Article article)
    {
        if (ModelState.IsValid)
        {
            var user = await _userManager.GetUserAsync(User);
            article.ContributorUsername = user.UserName;
            article.CreateDate = DateTime.Now;
            _context.Articles.Add(article);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(article);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var article = await _context.Articles.FindAsync(id);
        if (article == null || article.ContributorUsername != User.Identity.Name)
        {
            return NotFound();
        }
        return View(article);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Article article)
    {
        if (ModelState.IsValid)
        {
            _context.Articles.Update(article);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(article);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var article = await _context.Articles.FindAsync(id);
        if (article == null || article.ContributorUsername != User.Identity.Name)
        {
            return NotFound();
        }
        return View(article);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var article = await _context.Articles.FindAsync(id);
        _context.Articles.Remove(article);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}