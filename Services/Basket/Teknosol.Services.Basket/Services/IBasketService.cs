using System.Threading.Tasks;
using Teknosol.Services.Basket.Dtos;
using Teknosol.Shared.Dtos;

namespace Teknosol.Services.Basket.Services
{
    public interface IBasketService
    {
        Task<Response<BasketDto>> GetBasketAsync(string userId);
        Task<Response<bool>> SaveOrUpdateAsync(BasketDto basketDto);
        Task<Response<bool>> Delete(string userId);
    }
}