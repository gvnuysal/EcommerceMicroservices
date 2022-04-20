using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Teknosol.Services.PhotoStock.Dtos;
using Teknosol.Shared.Dtos;

namespace Teknosol.Services.PhotoStock.Services
{
    public  class PhotoService:IPhotoService
    {
        public async Task<Response<PhotoDto>> PhotoSaveAsync(IFormFile photo, CancellationToken cancellationToken)
        {
            if (photo != null && photo.Length > 0)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/photos", photo.FileName);
                using var stream=new FileStream(path,FileMode.Create);
                await photo.CopyToAsync(stream,cancellationToken);
                
                var returnPath = $"photos/{photo.FileName}";
                PhotoDto photoDto = new()
                {
                    Url = returnPath
                };

                return Response<PhotoDto>.Success(photoDto,200);
            }

            return Response<PhotoDto>.Fail("Photo is empty", 400);
        }

        public  Task PhotoDeleteAsync(string photoUrl)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/photos", photoUrl);
            if (!File.Exists(path))
            { 
                return Task.FromResult( Response<NoContent>.Fail("Photo not found", 404));
            }
            File.Delete(path);
            return Task.FromResult(Response<NoContent>.Success(204));
        }
    }
}