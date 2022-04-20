using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Teknosol.Services.PhotoStock.Dtos;
using Teknosol.Shared.Dtos;

namespace Teknosol.Services.PhotoStock.Services
{
    public interface IPhotoService
    {
        Task<Response<PhotoDto>> PhotoSaveAsync(IFormFile photo, CancellationToken cancellationToken);
        Task PhotoDeleteAsync(string photoUrl);
    }
}