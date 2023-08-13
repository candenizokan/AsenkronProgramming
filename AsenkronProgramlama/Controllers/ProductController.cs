using Microsoft.AspNetCore.Mvc;

namespace AsenkronProgramlama.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
