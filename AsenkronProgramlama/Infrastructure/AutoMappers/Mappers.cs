using AsenkronProgramlama.Models.DTOs;
using AsenkronProgramlama.Models.Entities.Concrete;
using AsenkronProgramlama.Models.VMs;
using AutoMapper;

namespace AsenkronProgramlama.Infrastructure.AutoMappers
{
    public class Mappers:Profile
    {
        public Mappers()
        {
            CreateMap<CreateCategoryDTO, Category>().ReverseMap();//CreateCategoryDTO alanlara bak bana Category nesne ver.ReverseMap() eşleşmenin iki yönlü çalışması

            //CreateMap<CreateCategoryDTO, Category>().ReverseMap().ForMember(a=>a.Slug,opt=>opt.Ignore());//=>Ignore et slug taşıma

            CreateMap<Category, UpdateCategoryDTO>().ReverseMap();
            CreateMap<CreateProductVM, Product>();//create product sağladığımda product yapman lazım bunun için map yapmam lazım

        }
    }
}
