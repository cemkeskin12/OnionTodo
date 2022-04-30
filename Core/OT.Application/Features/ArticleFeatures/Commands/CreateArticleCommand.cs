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
            private readonly IAppDbContext dbContext;
            private readonly IArticleRepository articleRepository;
            private readonly IUnitOfWork unitOfWork;

            public CreateArticleCommandHandler(IAppDbContext dbContext, IArticleRepository articleRepository, IUnitOfWork unitOfWork)
            {
                this.dbContext = dbContext;
                this.articleRepository = articleRepository;
                this.unitOfWork = unitOfWork;
            }
            public async Task<Unit> Handle(CreateArticleCommand request, CancellationToken cancellationToken)
            {
                var article = new Article();
                article.Title = request.Title;
                article.Content = request.Content;
                article.Note = request.Note;
                article.CreatedDate = DateTime.Now;
                await unitOfWork.ArticleRepository.AddAsync(article);
                await unitOfWork.BeginTransactionAsync();
                return await Task.FromResult(Unit.Value);

            }
        }
    }
}
