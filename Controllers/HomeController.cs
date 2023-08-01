using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using App.Models;
using App.Data;
using Microsoft.EntityFrameworkCore;
using App.ViewModels;

namespace App.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly AppDbContext _appDbContext;

    public HomeController(ILogger<HomeController> logger, AppDbContext appDbContext)
    {
        _logger = logger;
        _appDbContext = appDbContext;
    }

    public async Task<IActionResult> IndexAsync()
    {
        var categories = await _appDbContext.Categories
            .ToListAsync();

        var books = await _appDbContext.Books
            .ToListAsync();

        var viewModel = categories.GroupJoin(
            books,
            category => category.Id,
            book => book.CategoryId,
            (category, books) => new CategoryViewModel
            {
                CategoryId = category.Id,
                CategoryName = category.Name,
                BookCount = books.Count(),
                AverageBookNumberOfPages = books.Average(x => x.NumberOfPages)                
            }
        );    

        return View(viewModel);
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