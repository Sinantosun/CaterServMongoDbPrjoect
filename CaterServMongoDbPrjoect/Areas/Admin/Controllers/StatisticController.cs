using AutoMapper;
using CaterServMongoDbPrjoect.Dtos.StatisticDtos;
using CaterServMongoDbPrjoect.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CaterServMongoDbPrjoect.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class StatisticController : Controller
    {
        private readonly IStatisticService _statisticService;
        private readonly IMapper _mapper;

        public StatisticController(IStatisticService StatisticService, IMapper mapper)
        {
            _statisticService = StatisticService;
            _mapper = mapper;

        }

        public async Task<IActionResult> Index()
        {
            var values = await _statisticService.GetAllStatisticsAsync();
            return View(values);
        }
        [HttpGet]
        public IActionResult CreateStatistic()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateStatistic(CreateStatisticDto createStatisticDto)
        {
            await _statisticService.CreateStatisticAsync(createStatisticDto);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateStatistic(string id)
        {
            var value = await _statisticService.GetStatisticByIdAsync(id);
            var mappedValue = _mapper.Map<UpdateStatisticDto>(value);
            return View(mappedValue);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateStatistic(UpdateStatisticDto updateStatisticDto)
        {
            await _statisticService.UpdateStatisticAsync(updateStatisticDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteStatistic(string id)
        {
            await _statisticService.DeleteStatisticAsync(id);
            return RedirectToAction("Index");
        }
    }
}
