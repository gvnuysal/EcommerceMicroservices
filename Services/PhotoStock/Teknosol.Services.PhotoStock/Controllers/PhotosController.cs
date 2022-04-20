using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Teknosol.Services.PhotoStock.Dtos;
using Teknosol.Services.PhotoStock.Services;
using Teknosol.Shared.Dtos;

namespace Teknosol.Services.PhotoStock.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotosController : ControllerBase,IPhotoService
    {
        private readonly IPhotoService _photoService;

        public PhotosController(IPhotoService photoService)
        {
            _photoService = photoService;
        }

        [HttpPost]
        public virtual Task<Response<PhotoDto>> PhotoSaveAsync(IFormFile photo, CancellationToken cancellationToken)
        {
            return _photoService.PhotoSaveAsync(photo, cancellationToken);
        }

        public virtual Task PhotoDeleteAsync(string photoUrl)
        {
            return _photoService.PhotoDeleteAsync(photoUrl);
        }
    }
}