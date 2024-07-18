﻿using AutoMapper;
using CaterServMongoDbPrjoect.DataAccsess.Entites;
using CaterServMongoDbPrjoect.Dtos.CategoryDtos;
using CaterServMongoDbPrjoect.Services.Abstract;
using CaterServMongoDbPrjoect.Settings;
using MongoDB.Driver;

namespace CaterServMongoDbPrjoect.Services.Concrete
{
    public class CategoryService : ICategoryService
    {
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMapper _mapper;
        public CategoryService(IMapper mapper, IDataBaseSettings dataBaseSettings)
        {

            var client = new MongoClient(dataBaseSettings.ConnectionString);
            var database = client.GetDatabase(dataBaseSettings.DataBaseName);
            _categoryCollection = database.GetCollection<Category>(dataBaseSettings.CategoryCollectionName);
            _mapper = mapper;
        }

        public async Task CreateCategory(CreateCategoryDto category)
        {
            var values = _mapper.Map<Category>(category);
            await _categoryCollection.InsertOneAsync(values);
        }

        public async Task DeleteCategory(string id)
        {
            await _categoryCollection.DeleteOneAsync(x => x.CategoryId == id);
        }

        public async Task<List<ResultCategoryDto>> GetAllCategories()
        {
            var values = await _categoryCollection.AsQueryable().ToListAsync();
            return _mapper.Map<List<ResultCategoryDto>>(values);
        }

        public async Task<ResultCategoryDto> GetCategoryById(string id)
        {
            var value = await _categoryCollection.Find(x=>x.CategoryId == id).FirstOrDefaultAsync();
            return _mapper.Map<ResultCategoryDto>(value);
        }

        public async Task UpdateCategory(UpdateCategoryDto category)
        {
            var values = _mapper.Map<Category>(category);
            await _categoryCollection.FindOneAndReplaceAsync(x=>x.CategoryId==values.CategoryId,values);
        }
    }
}
