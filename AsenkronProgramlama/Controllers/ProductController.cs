using Microsoft.AspNetCore.Mvc;

namespace AsenkronProgramlama.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Create()
        {
            return View();
        }
    }
}
