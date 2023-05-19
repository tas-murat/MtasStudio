using MediatR;
using Microsoft.AspNetCore.Mvc;
using MtasStudio.Application.Features.Queries.GetCategoryById;
using MtasStudio.Application.Features.Queries.GetCategoryies;
using MtasStudio.Application.Features.Queries.ViewModels;
using MtasStudio.Application.Models;
using MtasStudio.Domain.Models.Result.Abstract;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MtasStudio.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator mediator;

        public CategoryController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("categoryies")]
        [ProducesResponseType(typeof(IDataResult<PagingResult<CategoryViewModel>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(IDataResult<IEnumerable<CategoryViewModel>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CategoryiesAsync([FromQuery] int pageSize = 10, [FromQuery] int pageIndex = 0, [FromQuery] bool isAscending=true, [FromQuery] string propertyName="Id")
        {
            PagingResponse pagingResponse = new PagingResponse
            {
                PageIndex= pageIndex,
                PageSize= pageSize,
                SortingResponse=new SortingResponse
                {
                    IsAscending=isAscending,
                    PropertyName=propertyName
                }
            };
            var res = await mediator.Send(new GetCategoriesQuery(pagingResponse));
            if (res != null)
            {
                return Ok(res);
            }
            else
            {
                return NotFound();
            }
        }

       

      
    }
}
