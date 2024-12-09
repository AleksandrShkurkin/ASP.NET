using Microsoft.AspNetCore.Mvc;

public class UserController : Controller
{
    private readonly AppDbContext _context;

    public UserController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult IndexUser()
    {
        var users = _context.User.ToList();
        return View(users);
    }

    [HttpPost]
    public IActionResult AddUsers()
    {
        var users = new List<User>
        {
            new User { FirstName = "Mike", LastName = "Lorece", Age = 30},
            new User { FirstName = "Daniel", LastName = "Framing", Age = 23},
            new User { FirstName = "Fridrich", LastName = "Schnitzel", Age = 45},
        };

        _context.User.AddRange(users);
        _context.SaveChanges();

        return RedirectToAction("IndexUser");
    }

    [HttpPost]
    public IActionResult RemoveUsers()
    {
        var threeUsers = _context.User
        .OrderByDescending(u => u.Id)
        .Take(3)
        .ToList();

        if (threeUsers.Any())
        {
            _context.User.RemoveRange(threeUsers);
            _context.SaveChanges();
        }

        return RedirectToAction("IndexUser");
    }
}