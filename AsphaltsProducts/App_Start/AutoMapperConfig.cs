using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AsphaltsProducts.Presentation.Layer.Models;
using AsphaltsProducts.Service.Layer.ECommerce.ProductsService.Dto;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using AutoMapper.XpressionMapper.Extensions;
using AutoMapper.Mappers;
using AutoMapper.Configuration;
using AutoMapper.Internal;
using AutoMapper.Execution;

namespace AsphaltsProducts.Presentation.Layer.App_Start
{
    public  class AutoMapperConfig : Profile
    {
        public  void RegisterMappings()
        {
            CreateMap<ProductViewModel, ProductDto>(MemberList.None).ReverseMap().ForAllMembers(x=> { x.Ignore(); });
            CreateMap<IList<ProductViewModel>, IList<ProductDto>>(MemberList.None).ReverseMap();
            //CreateMap<ProductCategoryViewModel, ProductDto>().ReverseMap();

        }
    }
}
