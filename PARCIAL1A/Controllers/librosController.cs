using Microsoft.AspNetCore.Mvc;

namespace PARCIAL1A.Controllers
{
    public class librosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
