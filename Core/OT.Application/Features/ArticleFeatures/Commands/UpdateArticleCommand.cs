using MediatR;
using OT.Application.Features.DependencyInjection;
using OT.Application.Interfaces.UnitOfWorks;

namespace OT.Application.Features.ArticleFeatures.Commands
{
    public class UpdateArticleCommand : IRequest
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Note { get; set; }
    }
    public class UpdateArticleCommandHandler : UnitOfWorkDependencyInjection, IRequestHandler<UpdateArticleCommand>
    {

        public UpdateArticleCommandHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        public async Task<Unit> Handle(UpdateArticleCommand request, CancellationToken cancellationToken)
        {
            var article = await UnitOfWork.ArticleRepository.GetByIdAsync(request.Id);
            article.SetTitle(request.Title);
            article.SetContent(request.Content);
            article.SetNote(request.Note);
            await UnitOfWork.ArticleRepository.Update(article);
            await UnitOfWork.SaveAsync();
            return await Task.FromResult(Unit.Value);
        }
    }
}
