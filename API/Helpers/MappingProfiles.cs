using API.Dtos;
using AutoMapper;
using Core.Entities;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductToReturnDto>()
                    .ForMember(d=>d.ProductBrand, o=>o.MapFrom(s=>s.ProductBrand.Name))
                    .ForMember(x=>x.ProductType,y=>y.MapFrom(g=>g.ProductType.Name))
                    .ForMember(d=>d.PictureUrl ,o=>o.MapFrom<ProductUrlResolver>());
                    
            
        }
    }
}