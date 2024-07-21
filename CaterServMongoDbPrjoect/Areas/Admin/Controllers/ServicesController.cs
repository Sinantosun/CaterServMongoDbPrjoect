using AutoMapper;
using CaterServMongoDbPrjoect.Dtos.ServiceDtos;
using CaterServMongoDbPrjoect.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CaterServMongoDbPrjoect.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class ServicesController : Controller
    {
        private readonly IServicesService _servicesService;
        private readonly IMapper _mapper;

        public ServicesController(IServicesService servicesService, IMapper mapper)
        {
            _servicesService = servicesService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _servicesService.GetAllServicesAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateService()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateService(CreateServiceDto createServiceDto)
        {
            await _servicesService.CreateServiceAsync(createServiceDto);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateService(string id)
        {
            var value = await _servicesService.GetServiceByIdAsync(id);
            var mappedValue = _mapper.Map<UpdateServiceDto>(value);
            return View(mappedValue);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateService(UpdateServiceDto updateServiceDto)
        {
            await _servicesService.UpdateServiceAsync(updateServiceDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteService(string id) 
        {
            await _servicesService.DeleteServiceAsync(id);
            return RedirectToAction("Index");
        }
    }
}
