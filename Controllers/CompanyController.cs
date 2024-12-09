using Microsoft.AspNetCore.Mvc;

public class CompanyController : Controller
{
    private readonly AppDbContext _context;

    public CompanyController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var companies = _context.Company.ToList();
        return View(companies);
    }

    [HttpPost]
    public IActionResult Add(string name, string address)
    {
        if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(address))
        {
            return BadRequest("Name and address must not be empty.");
        }

        _context.Company.Add(new Company {Name = name, Address = address});
        _context.SaveChanges();

        return RedirectToAction("Index");
    }
}