﻿using AutoMapper;
using HomeSecurity.BLL.DTOs.Users;
using HomeSecurity.BLL.Interfaces.Services;
using HomeSecurity.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using IdentitySignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace HomeSecurity.BLL.Services;

public class AuthService(
    UserManager<User> userManager,
    SignInManager<User> signInManager,
    IMapper mapper) : IAuthService
{
    public async Task<IdentityResult> RegisterAsync(UserRegisterDto registerDto)
    {
        var user = mapper.Map<User>(registerDto);

        var result = await userManager.CreateAsync(user, registerDto.Password);
        if (!result.Succeeded)
            return result;

        return result;
    }

    public async Task<IdentitySignInResult> LoginAsync(UserLoginDto loginDto)
    {
        var user = await userManager.FindByEmailAsync(loginDto.Email);
        if (user == null)
        {
            return IdentitySignInResult.Failed;
        }

        var result = await signInManager.PasswordSignInAsync(
            user,
            loginDto.Password,
            loginDto.RememberMe,
            lockoutOnFailure: false
        );

        return result;
    }

    public async Task LogoutAsync()
    {
        await signInManager.SignOutAsync();
    }
}