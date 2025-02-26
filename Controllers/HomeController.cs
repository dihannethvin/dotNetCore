using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DotnetCoreWebApp.Models;

namespace DotnetCoreWebApp.Controllers;

public class HomeController : Controller
{
    private readonly AppDbContext _context;

    public HomeController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        // Fetch users from the database
        var users = _context.Users.ToList();
        return View(users);  // Pass users to the view
    }

    public IActionResult About()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Register(User user)
    {
        if (ModelState.IsValid)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            ViewData["Message"] = "Registration Successful!";
            return RedirectToAction("Index"); // Redirect to prevent form resubmission
        }

        return View("Index", user); // Return the same view with validation errors
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
