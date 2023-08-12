using AsenkronProgramlama.Infrastructure.Repositories.Interfaces;
using AsenkronProgramlama.Models.DTOs;
using AsenkronProgramlama.Models.Entities.Concrete;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using AsenkronProgramlama.Models.Enums;

namespace AsenkronProgramlama.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryDTO dto)
        {
            if (ModelState.IsValid)
            {
                Category nesne = await _categoryRepository.GetByDefault(a => a.Slug == dto.Slug);  //kategory repoya ihtiyacım var. o zaman di ile reoyu ctorda alacam soyut halini alacağım somutu verecek//_categoryRepository.GetByDefault(a => a.Slug == dto.Slug); içeride bu isimle bir kayıt var demektir

                if (nesne == null)
                {
                    /* böyle her property yazmak yerine automapper kütüphanesi ekleyebilirim
                    Category category = new Category();
                    category.Name = dto.Name;
                    category.Slug = dto.Slug;
                    */

                    Category category = _mapper.Map<Category>(dto);

                    await _categoryRepository.Add(category);

                    return RedirectToAction("List");



                }
            }

            return View(dto);
        }

        public async Task<IActionResult> List()
        {
            var categoryList = await _categoryRepository.GetByDefaults(a => a.Statu != Statu.Passive);
            return View(categoryList);
        }


        public async Task<IActionResult> Edit(int id)
        {
            Category category = await _categoryRepository.GetById(id);

            /*
            UpdateCategoryDTO updateCategoryDTO = new UpdateCategoryDTO();
            updateCategoryDTO.ID=category.ID;
            updateCategoryDTO.Name=category.Name;
            */
            var model = _mapper.Map<UpdateCategoryDTO>(category);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateCategoryDTO dto)
        {
            if (ModelState.IsValid)
            {
                Category category = await _categoryRepository.GetByDefault(a=>a.Slug == dto.Slug);
                if (category == null)
                {
                    var nesne = _mapper.Map<Category>(dto);
                    await _categoryRepository.Update(nesne);
                    return RedirectToAction("List");
                }
            }
            return View(dto);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            Category category = await _categoryRepository.GetByDefault(a => a.ID == id);
            return View(category);
        }

    }
}
