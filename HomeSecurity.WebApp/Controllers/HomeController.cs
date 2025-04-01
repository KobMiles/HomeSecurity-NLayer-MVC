using Microsoft.AspNetCore.Mvc;
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

    public IActionResult Error()
    {
        return View();
    }
}
