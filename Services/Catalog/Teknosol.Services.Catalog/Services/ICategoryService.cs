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
        Task<Response<List<CategoryDto>>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<Response<CategoryDto>> CreateAsync(Category category, CancellationToken cancellationToken = default);
        Task<Response<CategoryDto>> GetByIdAsync(string id, CancellationToken cancellationToken = default);
    }
}