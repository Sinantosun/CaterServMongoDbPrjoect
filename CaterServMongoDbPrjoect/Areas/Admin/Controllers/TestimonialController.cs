using AutoMapper;
using CaterServMongoDbPrjoect.Dtos.TestimonialDtos;
using CaterServMongoDbPrjoect.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CaterServMongoDbPrjoect.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class TestimonialController : Controller
    {
        private readonly ITestimonailService _testimonialService;
        private readonly IMapper _mapper;
        public TestimonialController(ITestimonailService testimonialService, IMapper mapper)
        {
            _testimonialService = testimonialService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _testimonialService.GetAllTestimonialAsync();
            return View(values);
        }
        [HttpGet]
        public IActionResult CreateTestimonial()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateTestimonial(CreateTestimonailDto createTestimonialDto)
        {
            await _testimonialService.CreateTestimonailAsync(createTestimonialDto);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateTestimonial(string id)
        {
            var value = await _testimonialService.GetTestimonailByIdAsync(id);
            var mappedValue = _mapper.Map<UpdateTestimonailDto>(value);
            return View(mappedValue);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateTestimonial(UpdateTestimonailDto updateTestimonialDto)
        {
            await _testimonialService.UpdateTestimonailAsync(updateTestimonialDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteTestimonial(string id)
        {
            await _testimonialService.DeleteTestimonailAsync(id);
            return RedirectToAction("Index");
        }
    }
}
