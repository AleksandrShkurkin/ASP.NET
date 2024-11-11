using Microsoft.AspNetCore.Mvc;

public class OrderController : Controller
{
    private static User _user;
    private static List<Product> _products;

    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Register(User user)
    {
        if (ModelState.IsValid)
        {
            if(user.Age > 16)
            {
                _user = user;
                return RedirectToAction("ProductQuantity");
            }
            ModelState.AddModelError(string.Empty, "You have to be older than 16 to order on this site... GET OUT!");
        }
        return View(user);
    }

    public IActionResult ProductQuantity()
    {
        return View();
    }

    [HttpPost]
    public IActionResult ProductQuantity(int quantity)
    {
        if(quantity > 0)
        {
            _user.ProductQuantity = quantity;
            return RedirectToAction("OrderProducts");
        }
        ModelState.AddModelError(string.Empty, "Amount should be positive");
        return View();
    }

    public IActionResult OrderProducts()
    {
        _products = new List<Product>();
        for(int i = 0; i < _user.ProductQuantity; i++)
        {
            _products.Add(new Product());
        }
        return View(_products);
    }

    [HttpPost]
    public IActionResult OrderProducts(List<Product> products)
    {
        if(ModelState.IsValid)
        {
            _products = products;
            return RedirectToAction("OrderSummary");
        }
        return View(products);
    }

    public IActionResult OrderSummary()
    {
        ViewData["Username"] = _user.Name;
        return View(_products);
    }
}