using MediatR;
using OT.Application.Interfaces.UnitOfWorks;
using OT.Domain.Entities;

namespace OT.Application.Features.ArticleFeatures.Queries
{
    public class GetArticleByIdQuery : IRequest<Article>
    {
        public int Id { get; set; }
        public class GetArticleByIdQueryHandler : IRequestHandler<GetArticleByIdQuery, Article>
        {
            private readonly IUnitOfWork unitOfWork;

            public GetArticleByIdQueryHandler(IUnitOfWork unitOfWork)
            {
                this.unitOfWork = unitOfWork;
            }

            public Task<Article> Handle(GetArticleByIdQuery request, CancellationToken cancellationToken)
            {
                var article = unitOfWork.ArticleRepository.GetByIdAsync(request.Id);
                return article;
            }
        }
    }
}
