using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OT.Application.Features.ArticleFeatures.Commands;

namespace OT.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ArticleController : BaseApiController
    {
        [HttpPost]
        public async Task<IActionResult> Create(CreateArticleCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
