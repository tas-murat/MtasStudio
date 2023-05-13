using AutoMapper;
using MtasStudio.Application.Features.Queries.ViewModels;
using MtasStudio.Domain.AggregateModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MtasStudio.Application.Mapping.CategoryMapping
{
    public class CategoryMappingProfile : Profile
    {
        public CategoryMappingProfile()
        {
            CreateMap<Category, CategoryViewModel>().ReverseMap();
        }
    }
}
