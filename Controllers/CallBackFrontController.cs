using BackForFrontVue2.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

[ApiController]
[Route("api/user")]
public class UserController : ControllerBase
{
    private readonly DatabaseService _databaseService;

    public UserController(DatabaseService databaseService)
    {
        _databaseService = databaseService;
    }

    [HttpGet("languageSkills/{username}")]
    public async Task<IActionResult> GetUserLanguageSkills(string username)
    {
        var result = await _databaseService.GetUserLanguageSkills(username);
        return Ok(result);
    }
}
