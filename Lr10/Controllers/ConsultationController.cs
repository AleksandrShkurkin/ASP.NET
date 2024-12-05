using Microsoft.AspNetCore.Mvc;

public class ConsultationController : Controller
{
    [HttpGet]
    public IActionResult Registration()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Registration(ConsultationForm model)
    {
        if (model.Product == "Basics" && model.ConsultationDate.DayOfWeek == DayOfWeek.Monday)
        {
            ModelState.AddModelError("Product", "Consultation on Basics can not be held at Monday.");
        }

        if (ModelState.IsValid)
        {
            return RedirectToAction("Success");
        }
        return View(model);
    }

    public IActionResult Success()
    {
        return View();
    }
}