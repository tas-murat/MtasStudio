using MediatR;
using MtasStudio.Application.Features.Queries.ViewModels;
using MtasStudio.Domain.Models.Result.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MtasStudio.Application.Features.Queries.GetCategoryById
{
    public class GetCategoryQuery : IRequest<IDataResult<CategoryViewModel>>
    {
        public int CategoryId { get; set; }

        public GetCategoryQuery(int categoryId)
        {
            CategoryId = categoryId;
        }
    }
}
