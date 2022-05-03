using MediatR;
using OT.Application.Interfaces.Context;
using OT.Application.Interfaces.Repositories;
using OT.Application.Interfaces.UnitOfWorks;
using OT.Domain.Entities;

namespace OT.Application.Features.ArticleFeatures.Commands
{
    public class CreateArticleCommand : IRequest
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Note { get; set; }

        public class CreateArticleCommandHandler : IRequestHandler<CreateArticleCommand>
        {
            private readonly IUnitOfWork unitOfWork;

            public CreateArticleCommandHandler(IUnitOfWork unitOfWork)
            {
                this.unitOfWork = unitOfWork;
            }
            public async Task<Unit> Handle(CreateArticleCommand request, CancellationToken cancellationToken)
            {
                var article = new Article(request.Title,request.Content,request.Note);
                await unitOfWork.ArticleRepository.AddAsync(article);
                await unitOfWork.SaveAsync();
                return await Task.FromResult(Unit.Value);

            }
        }
    }
}
