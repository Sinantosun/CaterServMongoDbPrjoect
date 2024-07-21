using AutoMapper;
using CaterServMongoDbPrjoect.Dtos.CheffDtos;
using CaterServMongoDbPrjoect.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CaterServMongoDbPrjoect.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class CheffController : Controller
    {
        private readonly ICheffService _CheffService;
        private readonly IMapper _mapper;

        public CheffController(ICheffService CheffService, IMapper mapper)
        {
            _CheffService = CheffService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _CheffService.GetAllCheffsAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateCheff()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCheff(CreateCheffDto createCheffDto)
        {
            await _CheffService.CreateCheffAsync(createCheffDto);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateCheff(string id)
        {
            var value = await _CheffService.GetCheffByIdAsync(id);
            var mappedValues = _mapper.Map<UpdateCheffDto>(value);
            return View(mappedValues);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCheff(UpdateCheffDto createCheffDto)
        {
            await _CheffService.UpdateCheffAsync(createCheffDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteCheff(string id)
        {
            await _CheffService.DeleteCheffAsync(id);
            return RedirectToAction("Index");
        }
    }
}
