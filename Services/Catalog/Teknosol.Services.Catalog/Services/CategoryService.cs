using System.Collections.Generic;
using System.Threading;
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
        public async Task<Response<List<CategoryDto>>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var categories = await _categoryCollection.Find(cat => true).ToListAsync(cancellationToken);
            return Response<List<CategoryDto>>.Success(_mapper.Map<List<CategoryDto>>(categories), 200);
        }

        /// <summary>
        /// create a category given by input
        /// </summary>
        /// <param name="category"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>return created category</returns>
        public async Task<Response<CategoryDto>> CreateAsync(Category category, CancellationToken cancellationToken = default)
        {
            await _categoryCollection.InsertOneAsync(category, cancellationToken: cancellationToken);
            return Response<CategoryDto>.Success(_mapper.Map<CategoryDto>(category), 200);
        }

        /// <summary>
        /// get a category with by input id
        /// </summary>
        /// <param name="id">parameter</param>
        /// <param name="cancellationToken"></param>
        /// <returns>return a category</returns>
        public async Task<Response<CategoryDto>> GetByIdAsync(string id, CancellationToken cancellationToken = default)
        {
            var category = await _categoryCollection.Find<Category>(x => x.Id == id).FirstOrDefaultAsync(cancellationToken);
            if (category == null)
            {
                return Response<CategoryDto>.Fail("Category not found", 404);
            }

            return Response<CategoryDto>.Success(_mapper.Map<CategoryDto>(category), 200);
        }
    }
}