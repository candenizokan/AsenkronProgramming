using AsenkronProgramlama.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace AsenkronProgramlama.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(CreateCategoryDTO dto)
        {
            return View(dto);
        }
        
    }
}
