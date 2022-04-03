using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Teknosol.Services.Catalog.Dtos;
using Teknosol.Shared.Dtos;

namespace Teknosol.Services.Catalog.Services
{
    public interface ICourseService
    {
        Task<Response<List<CourseDto>>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<Response<CourseDto>> GetByIdAsync(string id, CancellationToken cancellationToken = default);
        Task<Response<List<CourseDto>>> GetAllByUserIdAsync(string userId, CancellationToken cancellationToken = default);
        Task<Response<CourseDto>> CreateAsync(CourseCreateDto courseCreateDto);
        Task<Response<NoContent>> UpdateAsync(CourseUpdateDto courseUpdateDto);
        Task<Response<NoContent>> DeleteAsync(string id);
    }
}