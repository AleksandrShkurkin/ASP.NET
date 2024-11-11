using System.Text;
using Microsoft.AspNetCore.Mvc;

public class FileController : Controller
{
    [HttpGet]
    public IActionResult DownloadFile()
    {
        return View();
    }

    [HttpPost]
    public IActionResult DownloadFile(string firstName, string lastName, string text, string fileName)
    {
        if (string.IsNullOrEmpty(fileName))
        {
            fileName = "DefaultName";
        }

        string content = $"Author: {firstName} {lastName}\n{text}";
        byte[] fileBytes = Encoding.UTF8.GetBytes(content);

        return File(fileBytes, "text/plain", fileName + ".txt");
    }
}