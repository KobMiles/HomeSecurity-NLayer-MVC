using HomeSecurity.BLL.DTOs.Users;
using HomeSecurity.BLL.Interfaces.Services;
using HomeSecurity_NLayer_MVC.Filters;
using HomeSecurity_NLayer_MVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using HomeSecurity_NLayer_MVC.ViewModels;

namespace HomeSecurity_NLayer_MVC.Controllers;

public class AccountController(IAuthService authService, IUserService userService) : Controller
{

    [HttpGet, RedirectAuthenticated]
    public IActionResult Register() => View();

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(UserRegisterDto model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var result = await authService.RegisterAsync(model);
        if (result.Succeeded)
        {
            TempData["Success"] = "Registration successful! You can now log in.";
            return RedirectToAction(nameof(Login));
        }

        foreach (var error in result.Errors)
            ModelState.AddModelError(string.Empty, error.Description);

        return View(model);
    }

    [HttpGet, RedirectAuthenticated]
    public IActionResult Login(string? returnUrl = null)
    {
        ViewData["ReturnUrl"] = returnUrl;
        return View();
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(UserLoginDto model, string? returnUrl = null)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var result = await authService.LoginAsync(model);

        if (result.Succeeded)
        {
            if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        ModelState.AddModelError(string.Empty, "Invalid login attempt.");
        return View(model);
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Logout()
    {
        await authService.LogoutAsync();
        return RedirectToAction(nameof(Login));
    }

    [HttpGet, Authorize]
    public async Task<IActionResult> Profile()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var currentUser = await userService.GetUserDetailsAsync(userId!);
        var allUsers = await userService.GetAllUsersAsync();

        var viewModel = new ProfileViewModel
        {
            CurrentUser = currentUser,
            AllUsers = allUsers
        };

        return View(viewModel);
    }
}