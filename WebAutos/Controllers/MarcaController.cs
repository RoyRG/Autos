using Microsoft.AspNetCore.Mvc;

namespace WebAutos.Controllers
{
    public class MarcaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
