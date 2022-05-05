using MediatR;
using OT.Application.Features.DependencyInjection;
using OT.Application.Interfaces.UnitOfWorks;
using OT.Domain.Entities;

namespace OT.Application.Features.ArticleFeatures.Commands
{
    public class CreateArticleCommand : IRequest
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Note { get; set; }

        public class CreateArticleCommandHandler : UnitOfWorkDependencyInjection, IRequestHandler<CreateArticleCommand>
        {
            public CreateArticleCommandHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
            {
            }
            public async Task<Unit> Handle(CreateArticleCommand request, CancellationToken cancellationToken)
            {
                var article = new Article(request.Title, request.Content, request.Note);
                await UnitOfWork.ArticleRepository.AddAsync(article);
                await UnitOfWork.SaveAsync();
                return await Task.FromResult(Unit.Value);

            }
        }
    }
}
