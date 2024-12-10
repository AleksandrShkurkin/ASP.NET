using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Lr13.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HomeController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        Log.Debug("Це повідомлення рівня Debug");
        Log.Information("Користувач отримав дані");
        Log.Warning("Це попередження");
        Log.Error("Виникла помилка");
        Log.Fatal("Фатальна помилка!");
        
        Log.Information("Користувач {UserName} увійшов у систему о {LoginTime}", "TestUser", DateTime.Now);

        var user = new { Id = 1, Name = "TestUser" };
        Log.Information("Деталі користувача: {@User}", user);

        return Ok("Логи збережено!");
    }
}
