using AutoMapper;
using MediatR;
using MtasStudio.Application.Features.Queries.GetCategoryById;
using MtasStudio.Application.Features.Queries.ViewModels;
using MtasStudio.Application.Interfaces.Repositories;
using MtasStudio.Application.Models;
using MtasStudio.Domain.Models.Result.Abstract;
using MtasStudio.Domain.Models.Result.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MtasStudio.Application.Features.Queries.GetCategoryies
{
    public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, IDataResult<PagingResult<CategoryViewModel>>>
    {
        ICategoryRepository categoryRepository;
        private readonly IMapper mapper;

        public GetCategoriesQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            this.categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
            this.mapper = mapper;
        }

        public async Task<IDataResult<PagingResult<CategoryViewModel>>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {

            try
            {
                var pagingResult = await categoryRepository.GetPagedDataAsync(request.pagingResponse);


                IEnumerable<CategoryViewModel> categoryViewModel = mapper.Map<IEnumerable<CategoryViewModel>>(pagingResult.Data);

                PagingResult<CategoryViewModel> response = new PagingResult<CategoryViewModel>
                {
                    Data = categoryViewModel,
                    PageIndex = pagingResult.PageIndex,
                    TotalCount = pagingResult.TotalCount,
                    PageSize = pagingResult.PageSize

                };
                return new SuccessDataResult<PagingResult<CategoryViewModel>>(response);
            }
            catch (Exception e)
            {

                return new ErrorDataResult<PagingResult<CategoryViewModel>>(e.Message);
            }
          
        }
    }
}
