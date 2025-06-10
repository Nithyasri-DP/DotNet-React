using System.Diagnostics;
using Log4Net.Models;
using Microsoft.AspNetCore.Mvc;
using log4net;

namespace Log4Net.Controllers
{
    public class HomeController : Controller
    {
        private static readonly ILog logger1 = LogManager.GetLogger(typeof(HomeController));
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            logger1.Info("Index action method called");

            try
            {
                int x = 10, y = 0;
                int result = x / y;
            }
            catch (Exception ex)
            {
                logger1.Error("Error occured" +ex.Message);  
            }
            return View();
        }

        public JsonResult GetJsonResult()
        {
            var data = new { Name = "Nithya", Age = 20, Occupation = "FSD" };
            return Json(data);
        }

        public ContentResult GetContentResult()
        {
            string content = "Simple Content Result from HomeController";
            return Content(content);
        }

        //Redirect Result
        public IActionResult RedirectToGoogle()
        {
            return Redirect("https://www.google.com");
        }

        //Redirect to Action
        public IActionResult RedirectToPrivacy()
        {
            return RedirectToAction("Privacy", "Home");
        }

        //File Result
        public IActionResult DownloadTheFile()
        {
            byte[] fileBytes = System.IO.File.ReadAllBytes("wwwroot/sample.txt");
            return File(fileBytes, "application/octet-stream", "sample.txt");
        }

        //Status code Result
        public IActionResult NotFoundResult()
        {
            return StatusCode(404, "Requested resource was not found.");
        }

        //Empty Result
        public IActionResult EmptyResultExample()
        {
            return new EmptyResult();
        }

        public IActionResult Privacy()
        {
            logger1.Info("Privacy page accessed");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
