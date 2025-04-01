using HomeSecurity.BLL.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HomeSecurity_NLayer_MVC.Controllers;

[Authorize]
public class SecurityController(ISensorService sensorService, IAlarmService alarmService) : Controller
{
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        ViewBag.AlarmStatus = await alarmService.GetAlarmStatusAsync();
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> ToggleAlarm()
    {
        await alarmService.ToggleAlarmStatusAsync();
        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> GetAlarmStatus()
    {
        var status = await alarmService.GetAlarmStatusAsync();
        return Json(new { isActive = status });
    }

    [HttpGet]
    public async Task<IActionResult> GetSensors()
    {
        var updatedSensors = await sensorService.UpdateSensorsRandomlyAsync();
        return Json(updatedSensors);
    }
}