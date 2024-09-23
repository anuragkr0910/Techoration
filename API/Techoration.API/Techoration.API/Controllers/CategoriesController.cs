﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Techoration.API.Data;
using Techoration.API.Models.Domain;
using Techoration.API.Models.DTO;
using Techoration.API.Repositories.Interface;

namespace Techoration.API.Controllers
{
    // https://localhost:xxxx/api/categories
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoriesController(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        // POST: /api/categories
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryRequestDTO requestDTO)
        {
            // Map Request DTO to Domain Model
            var category = new Category()
            {
                Name = requestDTO.Name,
                URLHandle = requestDTO.URLHandle
            };

            await categoryRepository.CreateAsync(category);

            // Map Domain Model to Response DTO
            var response = new CategoryDTO()
            {
                Id = category.Id,
                Name = category.Name,
                URLHandle = category.URLHandle
            };

            return Ok(response);
        }


        // GET: /api/categories
        [HttpGet]
        public async Task<IActionResult> GetAllCategory()
        {
            var categories = await categoryRepository.GetAllAsync();

            var response = new List<CategoryDTO>();

            foreach (var category in categories)
            {
                response.Add(new CategoryDTO()
                {
                    Id = category.Id,
                    Name = category.Name,
                    URLHandle = category.URLHandle                   
                });              
            }
            return Ok(response);            
        }
    }
}
