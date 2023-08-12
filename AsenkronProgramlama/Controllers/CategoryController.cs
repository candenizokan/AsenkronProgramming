using Microsoft.AspNetCore.Mvc;

namespace AsenkronProgramlama.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
