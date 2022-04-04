using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Teknosol.Services.Catalog.Dtos;
using Teknosol.Services.Catalog.Models;
using Teknosol.Services.Catalog.Services;
using Teknosol.Shared.Dtos;

namespace Teknosol.Services.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase, ICategoryService
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        [Route("get-all")]
        public virtual Task<Response<List<CategoryDto>>> GetAllAsync()
        {
            return _categoryService.GetAllAsync();
        }

        [HttpPost]
        [Route("create")]
        public virtual Task<Response<CategoryDto>> CreateAsync(Category category)
        {
            return _categoryService.CreateAsync(category);
        }

        [HttpGet]
        [Route("get-by-id/{id}")]
        public virtual Task<Response<CategoryDto>> GetByIdAsync(string id)
        {
            return _categoryService.GetByIdAsync(id);
        }
    }
}