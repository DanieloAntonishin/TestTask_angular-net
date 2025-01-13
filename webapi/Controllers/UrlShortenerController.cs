using Microsoft.AspNetCore.Mvc;
using webapi.Repositories;

namespace webapi.Controllers;

[ApiController]
[Route("[controller]")]
public class UrlShortenerController : Controller
{
    IShortenerRepositories _shortenerRepositories { get; set; }
    public UrlShortenerController(IShortenerRepositories shortenerRepositories)
    {
        _shortenerRepositories = shortenerRepositories;
    }

    [HttpPost]
    public async Task<IActionResult> AddNewUrl(ShortenerUrl sUrl)
    {
        try
        {
            if (sUrl == null)
                return BadRequest();

            await _shortenerRepositories.AddNewUrlAsync(sUrl);      // Add new URL 
            return Json(new { key = "ID: ", value = sUrl.Id });
        }
        catch (Exception ex)
        {
            return Json(new { key = "Exception: ", value = ex.Message });
        }
    }

    [HttpPut]
    public async Task<IActionResult> ChangeUrl(ShortenerUrl sUrl)
    {
        try
        {
            if (sUrl == null)
                return BadRequest();

            await _shortenerRepositories.ChangeUrlAsync(sUrl);              // Change info about URL
            return Json(new { key = "Result: ", value = "Confirm" });
        }
        catch (Exception ex)
        {
            return Json(new { key = "Exception: ", value = ex.Message });
        }
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteUrl(Guid sUrlId)
    {
        try
        {
            if (sUrlId == Guid.Empty)
                return BadRequest();

            await _shortenerRepositories.DeleteUrlAsync(sUrlId);            // Delete user from table

            return Json(new { key = "Result: ", value = "Confirm" });
        }
        catch (Exception ex)
        {
            return Json(new { key = "Exception: ", value = ex.Message });
        }
    }

    [HttpDelete("all")]
    public async Task<IActionResult> DeleteAllUrl()
    {
        try
        {
            var url = await _shortenerRepositories.DeleteAllUrlAsync();

            return Json(new { url });
        }
        catch (Exception ex)
        {
            return Json(new { key = "Exception: ", value = ex.Message });
        }
    }

    [HttpGet("getById")]
    public async Task<IActionResult> GetUrlByUserId(Guid userId)
    {
        try
        {
            var user = await _shortenerRepositories.GetUrlByUserIdAsync(userId);

            return Json(new { user });
        }
        catch (Exception ex)
        {
            return Json(new { key = "Exception: ", value = ex.Message });
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetAllUrl()
    {
        try
        {
            var url = await _shortenerRepositories.GetUrlAsync();

            return Json(new { url });
        }
        catch (Exception ex)
        {
            return Json(new { key = "Exception: ", value = ex.Message });
        }
    }
}
