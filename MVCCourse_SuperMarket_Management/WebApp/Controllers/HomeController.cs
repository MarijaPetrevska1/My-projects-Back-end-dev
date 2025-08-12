using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    // HomeController - grouping of different action methods
    public class HomeController : Controller
    {
        // Any action method is used to handle request 
        // when the request comes into the server it will be mapped to one of the controller's action methods
        public IActionResult Index()
        {
            return View("Index"); // we can specify the view name here, example Index
        }
    }
}
