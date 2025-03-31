using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using HomeSecurity_NLayer_MVC.Models;
using HomeSecurity.BLL.Interfaces.Services;

namespace HomeSecurity_NLayer_MVC.Controllers;

public class HomeController(ISensorService sensorService) : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> GetSensors()
    {
        var updatedSensors = await sensorService.UpdateSensorsRandomlyAsync();
        return Json(updatedSensors);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
