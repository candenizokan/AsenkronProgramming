using AsenkronProgramlama.Infrastructure.Repositories.Interfaces;
using AsenkronProgramlama.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace AsenkronProgramlama.Controllers
{
    public class ProductController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;

        public ProductController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IActionResult> Create()
        {
            //bura category repoya ihtiyacım doğdu. bunu ctorda di ile alacağım

            //Not: normalde SelectListItem nesnelerini bir listeye doldurarak ve her bir kategori nesnesinden bir SelectListItem nesnesi oluşturarak da bu işlemi yapabilirdik. buda farklı bir yöntem olarak burada kalsın
            ViewBag.Categories =  new SelectList(await _categoryRepository.GetByDefaults(a => a.Statu != Statu.Passive), "ID", "Name");//pasive olmayan tüm kategorileri göndermem lazım
        }
    }
}
