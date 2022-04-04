using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Teknosol.Services.Catalog.Dtos;
using Teknosol.Services.Catalog.Models;
using Teknosol.Shared.Dtos;

namespace Teknosol.Services.Catalog.Services
{
    public interface ICategoryService
    {
        Task<Response<List<CategoryDto>>> GetAllAsync();
        Task<Response<CategoryDto>> CreateAsync(Category category);
        Task<Response<CategoryDto>> GetByIdAsync(string id);
    }
}