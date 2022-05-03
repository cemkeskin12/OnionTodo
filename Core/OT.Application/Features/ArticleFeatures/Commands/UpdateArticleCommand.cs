using MediatR;
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
    public class UpdateArticleCommandHandler : IRequestHandler<UpdateArticleCommand>
    {
        private readonly IUnitOfWork unitOfWork;

        public UpdateArticleCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<Unit> Handle(UpdateArticleCommand request, CancellationToken cancellationToken)
        {
            var article = await unitOfWork.ArticleRepository.GetByIdAsync(request.Id);
            article.SetTitle(request.Title);
            article.SetContent(request.Content);
            article.SetNote(request.Note);
            await unitOfWork.ArticleRepository.Update(article);
            await unitOfWork.SaveAsync();
            return await Task.FromResult(Unit.Value);
        }
    }
}
