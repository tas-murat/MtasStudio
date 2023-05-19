using AutoMapper;
using MediatR;
using MtasStudio.Application.Features.Queries.ViewModels;
using MtasStudio.Application.Interfaces.Repositories;
using MtasStudio.Domain.Models.Result.Abstract;
using MtasStudio.Domain.Models.Result.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MtasStudio.Application.Features.Queries.GetCategoryById
{
    public class GetCategoryQueryHandler :IRequestHandler<GetCategoryQuery, IDataResult<CategoryViewModel>>
    {
        ICategoryRepository categoryRepository;
    private readonly IMapper mapper;

    public GetCategoryQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
    {
        this.categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
        this.mapper = mapper;
    }

    public async Task<IDataResult<CategoryViewModel>> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
    {
            try
            {
                var order = await categoryRepository.GetByIdAsync(request.CategoryId, i => i.Children);
                if (order == null)
                {
                    return new ErrorDataResult<CategoryViewModel>("Category Not Found");
                }

                var result = mapper.Map<CategoryViewModel>(order);
                return new SuccessDataResult<CategoryViewModel>(result);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<CategoryViewModel>(e.Message);
            }
       
    }
}
}
