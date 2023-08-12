using AsenkronProgramlama.Models.DTOs;
using AsenkronProgramlama.Models.Entities.Concrete;
using AutoMapper;

namespace AsenkronProgramlama.Infrastructure.AutoMappers
{
    public class Mappers:Profile
    {
        public Mappers()
        {
            CreateMap<CreateCategoryDTO, Category>();//CreateCategoryDTO alanlara bak bana Category nesne ver
        }
    }
}
