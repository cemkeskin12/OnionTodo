using MediatR;
using OT.Application.Interfaces.UnitOfWorks;
using OT.Domain.Entities;

namespace OT.Application.Features.ArticleFeatures.Queries
{
    public class GetAllArticlesQuery : IRequest<IEnumerable<Article>>
    {
        public class GetAllArticlesQueryHandler : IRequestHandler<GetAllArticlesQuery, IEnumerable<Article>>
        {
            private readonly IUnitOfWork unitOfWork;

            public GetAllArticlesQueryHandler(IUnitOfWork unitOfWork)
            {
                this.unitOfWork = unitOfWork;
            }
            public async Task<IEnumerable<Article>> Handle(GetAllArticlesQuery request, CancellationToken cancellationToken)
            {
                var articles = await unitOfWork.ArticleRepository.GetAllAsync();
                return articles;
            }
        }
    }
}
