using Microsoft.AspNetCore.Mvc;

[Route("Product")]
public class ProductController : Controller
{
    [Route("List")]
    public ActionResult List()
    {
        var products = new List<Product>
        {
            new Product { Id = 1, Name = "Product A", Price = 100, CreateDate = DateTime.Now },
            new Product { Id = 2, Name = "Product B", Price = 200, CreateDate = DateTime.Now },
            new Product { Id = 3, Name = "Product C", Price = 300, CreateDate = DateTime.Now }
        };
        return View(products);
    }

    [Route("Table")]
    public ActionResult Table()
    {
        var products = new List<Product>
            {
                new Product { Id = 1, Name = "Product A", Price = 100, CreateDate = DateTime.Now },
                new Product { Id = 2, Name = "Product B", Price = 200, CreateDate = DateTime.Now },
                new Product { Id = 3, Name = "Product C", Price = 300, CreateDate = DateTime.Now }
            };

            return View(products);
    }
}