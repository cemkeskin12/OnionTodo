using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OT.Application.Features.ArticleFeatures.Commands;
using OT.Application.Features.ArticleFeatures.Queries;

namespace OT.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ArticleController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> List()
        {
            return Ok(await Mediator.Send(new GetAllArticlesQuery()));
        }
        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await Mediator.Send(new GetArticleByIdQuery { Id = id}));
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateArticleCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateArticleCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        
    }
}
