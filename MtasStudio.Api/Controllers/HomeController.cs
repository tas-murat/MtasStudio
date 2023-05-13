using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MtasStudio.Application.Features.Queries.GetCategoryById;
using MtasStudio.Application.Features.Queries.ViewModels;
using MtasStudio.Domain.Models.Result.Abstract;
using MtasStudio.Domain.Models.Result.Concrete;
using System.Net;

namespace MtasStudio.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IMediator mediator;

        public HomeController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(IDataResult<CategoryViewModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var res = await mediator.Send(new GetCategoryQuery(id));
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
