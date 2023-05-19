using MediatR;
using MtasStudio.Application.Features.Queries.ViewModels;
using MtasStudio.Application.Models;
using MtasStudio.Domain.Models.Result.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MtasStudio.Application.Features.Queries.GetCategoryies
{
    public class GetCategoriesQuery : IRequest<IDataResult<PagingResult<CategoryViewModel>>>
    {
        public PagingResponse pagingResponse { get; set; }
        public GetCategoriesQuery(PagingResponse pagingResponse)
        {
            this.pagingResponse = pagingResponse;
        }
    }
}
