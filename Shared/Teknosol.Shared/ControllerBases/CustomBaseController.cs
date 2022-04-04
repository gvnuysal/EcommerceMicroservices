using Microsoft.AspNetCore.Mvc;
using Teknosol.Shared.Dtos;

namespace Teknosol.Shared.ControllerBases
{
    public class CustomBaseController:ControllerBase
    {
        public IActionResult CreateActionResultInstance<T>(Response<T> response)
        {
            return new ObjectResult(response)
            {
                StatusCode = response.StatusCode
            };
        }
    }
}