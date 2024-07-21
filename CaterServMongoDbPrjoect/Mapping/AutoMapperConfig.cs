using AutoMapper;
using CaterServMongoDbPrjoect.DataAccsess.Entites;
using CaterServMongoDbPrjoect.Dtos.AboutDtos;
using CaterServMongoDbPrjoect.Dtos.CategoryDtos;
using CaterServMongoDbPrjoect.Dtos.CheffDtos;
using CaterServMongoDbPrjoect.Dtos.EventCategoryDtos;
using CaterServMongoDbPrjoect.Dtos.EventDtos;
using CaterServMongoDbPrjoect.Dtos.FeatureDtos;
using CaterServMongoDbPrjoect.Dtos.ProductDtos;
using CaterServMongoDbPrjoect.Dtos.ServiceDtos;
using CaterServMongoDbPrjoect.Dtos.TestimonialDtos;

namespace CaterServMongoDbPrjoect.Mapping
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {            ////CreateMap<ResultCategoryDto, Category>().ReverseMap();

            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category, ResultCategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();
            CreateMap<ResultCategoryDto, UpdateCategoryDto>().ReverseMap();

            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, ResultProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();
            CreateMap<ResultProductDto, UpdateProductDto>().ReverseMap();
  
            CreateMap<Feature, ResultFeatureDto>().ReverseMap();
            CreateMap<Feature, CreateFeatureDto>().ReverseMap();
            CreateMap<Feature, UpdateFeatureDto>().ReverseMap();
            CreateMap<ResultFeatureDto, UpdateFeatureDto>().ReverseMap();

            CreateMap<About, ResultAboutDto>().ReverseMap();
            CreateMap<About, CreateAboutDto>().ReverseMap();
            CreateMap<About, UpdateAboutDto>().ReverseMap();
            CreateMap<ResultAboutDto, UpdateAboutDto>().ReverseMap();

            CreateMap<Service, ResultServiceDto>().ReverseMap();
            CreateMap<Service, CreateServiceDto>().ReverseMap();
            CreateMap<Service, UpdateServiceDto>().ReverseMap();
            CreateMap<ResultServiceDto, UpdateServiceDto>().ReverseMap();

            CreateMap<Event, ResultEventDto>().ReverseMap();
            CreateMap<Event, UpdateEventDto>().ReverseMap();
            CreateMap<Event, CreateEventDto>().ReverseMap();
            CreateMap<ResultEventDto, UpdateEventDto>().ReverseMap();

            CreateMap<EventCategories, ResultEventCategoryDto>().ReverseMap();
            CreateMap<EventCategories, UpdateEventCategoryDto>().ReverseMap();
            CreateMap<EventCategories, CreateEventCategoryDto>().ReverseMap();
            CreateMap<ResultEventCategoryDto, UpdateEventCategoryDto>().ReverseMap();


            CreateMap<Cheff, ResultCheffDto>().ReverseMap();
            CreateMap<Cheff, UpdateCheffDto>().ReverseMap();
            CreateMap<Cheff, CreateCheffDto>().ReverseMap();
            CreateMap<ResultCheffDto, UpdateCheffDto>().ReverseMap();

            CreateMap<Testimonial, ResultTestimonailDto>().ReverseMap();
            CreateMap<Testimonial, CreateTestimonailDto>().ReverseMap();
            CreateMap<Testimonial, UpdateTestimonailDto>().ReverseMap();
            CreateMap<ResultTestimonailDto, UpdateTestimonailDto>().ReverseMap();
        }



    }
}
