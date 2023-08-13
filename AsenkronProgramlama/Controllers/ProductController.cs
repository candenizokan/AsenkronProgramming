using AsenkronProgramlama.Infrastructure.Repositories.Interfaces;
using AsenkronProgramlama.Models.Entities.Concrete;
using AsenkronProgramlama.Models.Enums;
using AsenkronProgramlama.Models.VMs;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
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
            //ViewBag.Categories =  new SelectList(await _categoryRepository.GetByDefaults(a => a.Statu != Statu.Passive), "ID", "Name");
            await FillCategories();
            //pasive olmayan tüm kategorileri göndermem lazım listeyi dolduruken içerdeki id yi id kabul et namei ni text kabul et gibi düşün.

            return View();
        }

        async Task FillCategories()
        {
            ViewBag.Categories = new SelectList(await _categoryRepository.GetByDefaults(a => a.Statu != Statu.Passive), "ID", "Name");
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

            //Tekrardan ViewBag doldurmalıyım ki olumsuz durumda kategoriyi göreyim. kod tekrarına düşmemek için tek yerde yaacağım her yerde çağırabilirim
            await FillCategories();
            return View(vm);
        }

        public async Task<IActionResult> List()
        {
            //PrpductVm oluşturacağım. orada db den tüm kolonları değil istediğim alanları göstereceğim

            //her bir product nesnesinden ProductVM nesnesini set etmeliyim

            var list = await _productRepository.GetFilter
                (
                    selector: a=>new ProductVM { Name = a.Name, ProductID=a.ID, Statu=a.Statu,CategoryName=a.Category.Name,Stock=a.Stock},
                    expression:a=>a.Statu!=Statu.Passive,
                    orderBy:a=>a.OrderByDescending(a=>a.Stock)//stok mktarına göre çoktan aza
                );
            return View(list);
        }

        public async Task<IActionResult> Edit(int id)
        {
            Product product = await _productRepository.GetById(id);

            //UpdateProductVM nesnesini doldurup göndermem lazım
            UpdateProductVM vm = _mapper.Map<UpdateProductVM>(product);
            await FillCategories();//kategorisini doldurum mapper bunu yapamıyor çünkü. bunu giddip runtimeda hata almamak için mappers sınıfında maplemeyi yapmam lazım. önce product tan vm e posta düşüncede vm den producta gideceğim bu durumda reverse olacak

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateProductVM vm)
        {
            if (ModelState.IsValid)
            {
               
                    var nesne = _mapper.Map<Product>(vm);//sen bana product ver vm'e bakarak
                    nesne.Category = await _categoryRepository.GetById(vm.CategoryID);
                    await _productRepository.Update(nesne);
                    return RedirectToAction("List");
                
            }
            await FillCategories();
            return View(vm);
        }

        public async Task<IActionResult> Delete(int id)
        {
            Product product = await _productRepository.GetByDefault(a => a.ID == id);//product ımı bul
            await _productRepository.Delete(product);
            return RedirectToAction("List");
        }
    }
}
