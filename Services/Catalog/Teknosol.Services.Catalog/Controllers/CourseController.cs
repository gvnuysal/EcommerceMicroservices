using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Teknosol.Services.Catalog.Dtos;
using Teknosol.Services.Catalog.Services; 
using Teknosol.Shared.Dtos;

namespace Teknosol.Services.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase, ICourseService
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet]
        [Route("get-all")]
        public virtual Task<Response<List<CourseDto>>> GetAllAsync()
        {
            return _courseService.GetAllAsync();
        }

        [HttpGet]
        [Route("get-by-id/{id}")]
        public virtual Task<Response<CourseDto>> GetByIdAsync(string id)
        {
            return _courseService.GetByIdAsync(id);
        }

        [HttpGet]
        [Route("get-all-by-user-id/{userid}")]
        public virtual Task<Response<List<CourseDto>>> GetAllByUserIdAsync(string userId)
        {
            return _courseService.GetAllByUserIdAsync(userId);
        }

        [HttpPost]
        [Route("create")]
        public virtual Task<Response<CourseDto>> CreateAsync(CourseCreateDto courseCreateDto)
        {
            return _courseService.CreateAsync(courseCreateDto);
        }

        
        [HttpPut]
        [Route("update")]
        public virtual Task<Response<NoContent>> UpdateAsync(CourseUpdateDto courseUpdateDto)
        {
            return _courseService.UpdateAsync(courseUpdateDto);
        }

        [HttpDelete]
        [Route("delete")]
        public virtual Task<Response<NoContent>> DeleteAsync(string id)
        {
            return _courseService.DeleteAsync(id);
        }
    }
}