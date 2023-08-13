using AsenkronProgramlama.Infrastructure.Repositories.Interfaces;
using AsenkronProgramlama.Models.Entities.Concrete;
using AsenkronProgramlama.Models.Enums;
using AsenkronProgramlama.Models.VMs;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace AsenkronProgramlama.Controllers
{
    public class ProductController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductController(ICategoryRepository categoryRepository, IProductRepository productRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
            _mapper = mapper;
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
                Product nesne = await _productRepository.GetByDefault(a => a.Slug == vm.Slug);
                if (nesne == null)
                {
                    //product nesnesi olouşturmaya hazırım
                    //Product product = new Product();
                    //product.Name = vm.Name;
                    //product.Description = vm.Description;
                    //product.Stock = vm.Stock;
                    //product.CategoryId = vm.CategoryID;
                    //product.Category=await _categoryRepository.GetById(vm.CategoryID);//ilişki durumu

                    //ben sana CreateProductVM nesnesi verdiğimde sen bakara Product ekle demem lazım. mapper ile gideceğim
                    Product product1=_mapper.Map<Product>(vm);
                    //Category nesnesini göremiyor mapper onu yapamıyor. bunu benim yazmam lazım
                    product1.Category = await _categoryRepository.GetById(vm.CategoryID);//nesnesini ben atadım.
                    await _productRepository.Add(product1);//al product ı ekle
                    return RedirectToAction("List");

                }
            }
            return View(vm);
        }
    }
}
