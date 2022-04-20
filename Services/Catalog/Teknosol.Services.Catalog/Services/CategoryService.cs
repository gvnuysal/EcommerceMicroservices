using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MongoDB.Driver;
using Teknosol.Services.Catalog.Dtos;
using Teknosol.Services.Catalog.Models;
using Teknosol.Services.Catalog.Settings;
using Teknosol.Shared.Dtos;

namespace Teknosol.Services.Catalog.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMapper _mapper;

        public CategoryService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _categoryCollection = database.GetCollection<Category>(databaseSettings.CategoryCollectionName);
            _mapper = mapper;
        }

        /// <summary>
        /// get all category information
        /// </summary>
        /// <returns>categories</returns>
        public async Task<Response<List<CategoryDto>>> GetAllAsync()
        {
            var categories = await _categoryCollection.Find(cat => true).ToListAsync();
            return Response<List<CategoryDto>>.Success(_mapper.Map<List<CategoryDto>>(categories) ,200,categories.Count);
        }

        /// <summary>
        /// create a category given by input
        /// </summary>
        /// <param name="category"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>return created category</returns>
        public async Task<Response<CategoryDto>> CreateAsync(Category category)
        {
            await _categoryCollection.InsertOneAsync(category);
            return Response<CategoryDto>.Success(_mapper.Map<CategoryDto>(category), 200);
        }

        /// <summary>
        /// get a category with by input id
        /// </summary>
        /// <param name="id">parameter</param>
        /// <param name="cancellationToken"></param>
        /// <returns>return a category</returns>
        public async Task<Response<CategoryDto>> GetByIdAsync(string id)
        {
            var category = await _categoryCollection.Find<Category>(x => x.Id == id).FirstOrDefaultAsync();
            if (category == null)
            {
                return Response<CategoryDto>.Fail("Category not found", 404);
            }

            return Response<CategoryDto>.Success(_mapper.Map<CategoryDto>(category), 200);
        }
    }
}