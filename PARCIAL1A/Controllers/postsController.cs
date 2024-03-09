using Microsoft.AspNetCore.Mvc;

namespace PARCIAL1A.Controllers
{
    public class postsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
