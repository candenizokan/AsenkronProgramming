using AsenkronProgramlama.Infrastructure.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AsenkronProgramlama.Controllers
{
    public class ProductController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;

        public ProductController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IActionResult Create()
        {
            ViewBag.Categories=//bura category repoya ihtiyacım doğdu. bunu ctorda di ile alacağım
        }
    }
}
