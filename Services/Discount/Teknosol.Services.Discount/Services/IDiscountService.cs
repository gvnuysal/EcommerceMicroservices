﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Teknosol.Shared.Dtos;

namespace Teknosol.Services.Discount.Services
{
    public interface IDiscountService
    {
        Task<Response<List<Models.Discount>>> GetAllAsync();
        Task<Response<Models.Discount>> GetByIdAsync(int id);
        Task<Response<NoContent>> SaveAsync(Models.Discount discount);
        Task<Response<NoContent>> UpdateAsync(Models.Discount discount);
        Task<Response<NoContent>> DeleteAsync(int id);
        Task<Response<Models.Discount>> GetByCodeAndUserIdAsync(string code, string userId);
    }
}