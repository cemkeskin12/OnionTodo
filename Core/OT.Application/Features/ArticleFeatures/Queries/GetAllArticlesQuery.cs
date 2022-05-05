using MediatR;
using OT.Application.Features.DependencyInjection;
using OT.Application.Interfaces.UnitOfWorks;
using OT.Domain.Entities;

namespace OT.Application.Features.ArticleFeatures.Queries
{
    public class GetAllArticlesQuery : IRequest<IEnumerable<Article>>
    {
        public class GetAllArticlesQueryHandler : UnitOfWorkDependencyInjection, IRequestHandler<GetAllArticlesQuery, IEnumerable<Article>>
        {
            public GetAllArticlesQueryHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
            {
            }
            public async Task<IEnumerable<Article>> Handle(GetAllArticlesQuery request, CancellationToken cancellationToken)
            {
                var articles = await UnitOfWork.ArticleRepository.GetAllAsync();
                return articles;
            }
        }
    }
}
