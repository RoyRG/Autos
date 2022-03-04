using Microsoft.AspNetCore.Mvc;

namespace WebAutos.Controllers
{
    public class LoteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
