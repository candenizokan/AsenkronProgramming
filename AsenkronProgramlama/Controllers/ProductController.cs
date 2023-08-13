using AsenkronProgramlama.Infrastructure.Repositories.Interfaces;
using AsenkronProgramlama.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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
            //bura category repoya ihtiyacım doğdu. bunu ctorda di ile alacağım
            ViewBag.Categories = new SelectListItem(_categoryRepository.GetByDefaults(a => a.Statu != Statu.Passive), "ID", "Name");//pasive olmayan tüm kategorileri göndermem lazım
        }
    }
}
