﻿using AsenkronProgramlama.Infrastructure.Repositories.Interfaces;
using AsenkronProgramlama.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace AsenkronProgramlama.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
       
        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(CreateCategoryDTO dto)
        {
            if (ModelState.IsValid)
            {
               var nesne = //kategory repoya ihtiyacım var. o zaman di ile reoyu ctorda alacam soyut halini alacağım somutu verecek
            }

            return View(dto);
        }
        
    }
}
