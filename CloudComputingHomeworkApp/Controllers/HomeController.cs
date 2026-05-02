using System.Diagnostics;
using CloudComputingHomeworkApp.Data;
using CloudComputingHomeworkApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CloudComputingHomeworkApp.Controllers;

public class HomeController : Controller
{
    private readonly ApplicationDbContext _dbContext;

    public HomeController(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IActionResult> Index()
    {
        return View(await BuildIndexViewModelAsync());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Index(HomeIndexViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(await BuildIndexViewModelAsync(model));
        }

        _dbContext.Persons.Add(new Person
        {
            Name = model.Name.Trim(),
            FavouriteNumber = model.FavouriteNumber!.Value
        });

        await _dbContext.SaveChangesAsync();
        TempData["StatusMessage"] = "Person saved successfully.";

        return RedirectToAction(nameof(Index));
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    private async Task<HomeIndexViewModel> BuildIndexViewModelAsync(HomeIndexViewModel? model = null)
    {
        model ??= new HomeIndexViewModel();
        model.Persons = await _dbContext.Persons
            .AsNoTracking()
            .OrderBy(person => person.Name)
            .ToListAsync();

        return model;
    }
}
