using AsenkronProgramlama.Infrastructure.Repositories.Interfaces;
using AsenkronProgramlama.Models.Entities.Concrete;
using AsenkronProgramlama.Models.Enums;
using AsenkronProgramlama.Models.VMs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace AsenkronProgramlama.Controllers
{
    public class ProductController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductRepository _productRepository;

        public ProductController(ICategoryRepository categoryRepository, IProductRepository productRepository)
        {
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
        }

        public async Task<IActionResult> Create()
        {
            //bura category repoya ihtiyacım doğdu. bunu ctorda di ile alacağım

            //Not: normalde SelectListItem nesnelerini bir listeye doldurarak ve her bir kategori nesnesinden bir SelectListItem nesnesi oluşturarak da bu işlemi yapabilirdik. buda farklı bir yöntem olarak burada kalsın
            ViewBag.Categories =  new SelectList(await _categoryRepository.GetByDefaults(a => a.Statu != Statu.Passive), "ID", "Name");//pasive olmayan tüm kategorileri göndermem lazım listeyi dolduruken içerdeki id yi id kabul et namei ni text kabul et gibi düşün.

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductVM vm)
        {
            if (ModelState.IsValid)
            {
                var nesne = await _productRepository.GetByDefault(a => a.Slug == vm.Slug);
                if (nesne == null)
                {
                    
                }
            }
            return View(vm);
        }
    }
}
