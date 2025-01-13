using Microsoft.AspNetCore.Mvc;
using System;
using webapi.Models;
using webapi.Repositories;

namespace webapi.Controllers;

[ApiController]
[Route("/user")]
public class UserController : Controller
{
    IUserRepositories _userRepositories { get; set; }
    public UserController(IUserRepositories userRepositories)
    {
        _userRepositories = userRepositories;
    }

    [HttpPost]
    public async Task<IActionResult> AddNewUser(User user)
    {
        try
        {
            if (user == null)
                return BadRequest();

            await _userRepositories.AddNewUserAsync(user);      // Add new User 
            return Json(new { key = "ID: ", value = user.Id });
        }
        catch (Exception ex)
        {
            return Json(new { key = "Exception: ", value = ex.Message });
        }
    }

    [HttpPut]
    public async Task<IActionResult> ChangeUser(User user)
    {
        try
        {
            if (user == null)
                return BadRequest();

            await _userRepositories.ChangeUserAsync(user);              // Change info about user
            return Json(new { key = "Result: ", value = "Confirm" });
        }
        catch (Exception ex)
        {
            return Json(new { key = "Exception: ", value = ex.Message });
        }
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteUser(Guid userId)
    {
        try
        {
            if (userId == Guid.Empty)
                return BadRequest();

            await _userRepositories.DeleteUserAsync(userId);            // Delete user from table

            return Json(new { key = "Result: ", value = "Confirm" });
        }
        catch (Exception ex)
        {
            return Json(new { key = "Exception: ", value = ex.Message });
        }
    }

    [HttpGet("getById")]
    public async Task<IActionResult> GetUserById(Guid userId)
    {
        try
        {
            var user = await _userRepositories.GetUserByIdAsync(userId);

            return Json(new { user });
        }
        catch (Exception ex)
        {
            return Json(new { key = "Exception: ", value = ex.Message });
        }
    }

    [HttpPost("authentication")]
    public async Task<IActionResult> Authentication([FromBody] LoginModel auth)
    {
        try
        {
            var user = await _userRepositories.AuthenticationAsync(auth.Login,auth.Password);

            return Json(new {user });
        }
        catch (Exception ex)
        {
            return Json(new { key = "Exception: ", value = ex.Message });
        }
    }
}
