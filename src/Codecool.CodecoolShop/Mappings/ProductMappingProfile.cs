using System.Collections.Generic;
using AutoMapper;
using Codecool.CodecoolShop.Models.Products;
using Codecool.CodecoolShop.Models.Products.DTO;

namespace Codecool.CodecoolShop.Mappings
{
    public class ProductMappingProfile : Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<KeyValuePair<Product, int>, ProductDto>()
                .ForMember(x => x.Quantity, configuration => configuration.MapFrom(y => y.Value))
                .ForMember(x => x.Name, configuration => configuration.MapFrom(y => y.Key.Name))
                .ForMember(x => x.PricePerUnit, configuration => configuration.MapFrom(y => y.Key.DefaultPrice));
        }
    }
}
