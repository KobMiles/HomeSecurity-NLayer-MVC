using HomeSecurity.BLL.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HomeSecurity_NLayer_MVC.Controllers;
[Authorize]
public class SecurityController(ISensorService sensorService) : Controller
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
}