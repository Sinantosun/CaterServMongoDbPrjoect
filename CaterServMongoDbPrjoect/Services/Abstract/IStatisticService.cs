﻿using CaterServMongoDbPrjoect.Dtos.AboutDtos;

namespace CaterServMongoDbPrjoect.Services.Abstract
{
    public interface IStatisticService
    {
        Task<List<ResultAboutDto>> GetAllAboutsAsync();
        Task<ResultAboutDto> GetAboutByIdAsync(string id);
        Task UpdateAboutAsync(UpdateAboutDto aboutDto);
        Task CreateAboutAsync(CreateAboutDto aboutDto);
        Task DeleteAboutAsync(string id);
    }
}
