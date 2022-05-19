using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Teknosol.Services.Discount.Services;
using Teknosol.Shared.Dtos;
using Teknosol.Shared.Services;

namespace Teknosol.Services.Discount.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountsController : ControllerBase, IDiscountService
    {
        private readonly IDiscountService _discountService;
        private readonly ISharedIdentityService _sharedIdentityService;

        public DiscountsController(ISharedIdentityService sharedIdentityService, IDiscountService discountService)
        {
            _sharedIdentityService = sharedIdentityService;
            _discountService = discountService;
        }

        [HttpGet]
        public virtual Task<Response<List<Models.Discount>>> GetAllAsync()
        {
            return _discountService.GetAllAsync();
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<Response<Models.Discount>> GetByIdAsync(int id)
        {
            return _discountService.GetByIdAsync(id);
        }

        [HttpPost]
        public virtual Task<Response<NoContent>> SaveAsync(Models.Discount discount)
        {
            return _discountService.SaveAsync(discount);
        }

        [HttpPut]
        public virtual Task<Response<NoContent>> UpdateAsync(Models.Discount discount)
        {
            return _discountService.UpdateAsync(discount);
        }

        [HttpDelete]
        public virtual Task<Response<NoContent>> DeleteAsync(int id)
        {
            return _discountService.DeleteAsync(id);
        }

        [HttpGet]
        [Route("get-by-code-and-user-id")]
        public Task<Response<Models.Discount>> GetByCodeAndUserIdAsync(string code, string userId)
        {
            return _discountService.GetByCodeAndUserIdAsync(code, _sharedIdentityService.GetUserId);
        }
    }
}