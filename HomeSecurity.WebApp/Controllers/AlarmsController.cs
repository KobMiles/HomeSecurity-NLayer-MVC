﻿using HomeSecurity.BLL.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HomeSecurity_NLayer_MVC.Controllers;

[Authorize]
public class AlarmsController(IAlarmService sensorAlertService) : Controller
{
    public async Task<IActionResult> Index(string sortOrder = "date_desc")
    {
        var alerts = await sensorAlertService.GetSensorAlertsAsync(sortOrder);
        ViewData["CurrentSort"] = sortOrder;
        return View(alerts);
    }
}