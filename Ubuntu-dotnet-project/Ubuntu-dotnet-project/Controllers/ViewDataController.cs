using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Ubuntu_dotnet_project.Models;

namespace Ubuntu_dotnet_project.Controllers;
public class ViewDataController : Controller
{
    private readonly ILogger<ViewDataController> _logger;

    public ViewDataController(ILogger<ViewDataController> logger)
    {
        _logger = logger;
    }
    
    public IActionResult Gewächshaustemperatur()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
