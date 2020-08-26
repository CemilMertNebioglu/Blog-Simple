using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using BloggerSample.BLL.Abstract;
using BloggerSample.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BloggerSample.WebAPI.Controllers
{
    [Route("api/Categories")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService categoryService;
        public CategoriesController(ICategoryService _categoryService)
        {
            categoryService = _categoryService;
        }
        [HttpGet]
        public List<CategoryDTO> Get()
        {
            return categoryService.getAll();
        }

        [HttpGet("{id}")]
        public CategoryDTO Get(int id)
        {
            return categoryService.getCategory(id);
        }
        [HttpPost]
        public CategoryDTO Post(CategoryDTO dto)
        {
            return categoryService.newCategory(dto);
        }
        [HttpPut]
        public CategoryDTO Put(CategoryDTO dto)
        {
            return categoryService.updateCategory(dto);
        }
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return categoryService.deleteCategory(id);
        }
    }
}