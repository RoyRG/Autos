using Microsoft.AspNetCore.Mvc;

namespace WebAutos.Controllers
{
    public class AutosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
