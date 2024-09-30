using Microsoft.AspNetCore.Http;
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
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryRequestDTO requestDTO)
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


        // GET: /api/Categories/{id}
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetCategoryByID([FromRoute] Guid id)
        {
            var category = await categoryRepository.GetCategoryById(id);

            if (category is null)
            {
                return NotFound();
            }

            var response = new CategoryDTO()
            {
                Id = category.Id,
                Name = category.Name,
                URLHandle = category.URLHandle
            };
            return Ok(response);
        }


        // PUT: /api/Categories/{id}
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateCategory([FromRoute] Guid id, [FromBody] UpdateCategoryRequestDTO requestDTO)
        {
            var category = new Category()
            {
                Id = id,
                Name = requestDTO.Name,
                URLHandle = requestDTO.URLHandle
            };

            category = await categoryRepository.UpdateAsync(category);

            if (category is null)
            { 
                return NotFound();
            }

            var response = new CategoryDTO()
            {
                Id = category.Id,
                Name = category.Name,
                URLHandle = category.URLHandle
            };

            return Ok(response);
        }
    }
}
