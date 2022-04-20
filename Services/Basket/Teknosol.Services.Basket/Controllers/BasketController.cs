using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Teknosol.Services.Basket.Dtos;
using Teknosol.Services.Basket.Services;
using Teknosol.Shared.Dtos;
using Teknosol.Shared.Services;

namespace Teknosol.Services.Basket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;
        private readonly ISharedIdentityService _sharedIdentityService;

        public BasketController(IBasketService basketService, ISharedIdentityService sharedIdentityService)
        {
            _basketService = basketService;
            _sharedIdentityService = sharedIdentityService;
        }

        [HttpGet]
        [Route("get-basket")]
        public virtual Task<Response<BasketDto>> GetBasketAsync()
        {
            return _basketService.GetBasketAsync(_sharedIdentityService.GetUserId);
        }

        [HttpPost]
        [Route("save-or-update-basket")]
        public virtual Task<Response<bool>> SaveOrUpdateAsync(BasketDto basketDto)
        {
            return _basketService.SaveOrUpdateAsync(basketDto);
        }

        [HttpDelete]
        [Route("delete-basket")]
        public virtual Task<Response<bool>> Delete()
        {
            return _basketService.Delete(_sharedIdentityService.GetUserId);
        }
    }
}