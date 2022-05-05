using MediatR;
using OT.Application.Features.DependencyInjection;
using OT.Application.Interfaces.UnitOfWorks;
using OT.Domain.Entities;

namespace OT.Application.Features.ArticleFeatures.Queries
{
    public class GetArticleByIdQuery : IRequest<Article>
    {
        public int Id { get; set; }
        public class GetArticleByIdQueryHandler : UnitOfWorkDependencyInjection, IRequestHandler<GetArticleByIdQuery, Article>
        {
            public GetArticleByIdQueryHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
            {
            }

            public Task<Article> Handle(GetArticleByIdQuery request, CancellationToken cancellationToken)
            {
                var article = UnitOfWork.ArticleRepository.GetByIdAsync(request.Id);
                return article;
            }
        }
    }
}
