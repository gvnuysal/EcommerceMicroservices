using System;
using System.Text.Json;
using System.Threading.Tasks;
using Teknosol.Services.Basket.Dtos;
using Teknosol.Shared.Dtos;

namespace Teknosol.Services.Basket.Services
{
    public class BasketService : IBasketService
    {
        private readonly RedisService _redisService;

        public BasketService(RedisService redisService)
        {
            _redisService = redisService;
        }

        public virtual async Task<Response<BasketDto>> GetBasketAsync(string userId)
        {
            var existsBasket = await _redisService.GetDatabase().StringGetAsync(userId);
            if (String.IsNullOrEmpty(existsBasket))
            {
                return Response<BasketDto>.Fail("Basket not found", 404);
            }

            return Response<BasketDto>.Success(JsonSerializer.Deserialize<BasketDto>(existsBasket), 200);
        }

        public virtual async Task<Response<bool>> SaveOrUpdateAsync(BasketDto basketDto)
        {
            var status = await _redisService.GetDatabase().StringSetAsync(basketDto.UserId, JsonSerializer.Serialize(basketDto));
            return status?Response<bool>.Success(204):Response<bool>.Fail("Bsket could not update or save",500);
        }

        public virtual async Task<Response<bool>> Delete(string userId)
        {
            var status = await _redisService.GetDatabase().KeyDeleteAsync(userId);
            return status?Response<bool>.Success(204):Response<bool>.Fail("Basket not found",404);
        }
    }
}