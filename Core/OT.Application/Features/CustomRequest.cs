using MediatR;
using OT.Application.Interfaces.UnitOfWorks;

namespace OT.Application.Features
{
    public class CustomRequest<TCommand> : IRequestHandler<TCommand> where TCommand : IRequest
    {
        public CustomRequest(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
        protected IUnitOfWork UnitOfWork { get; }

        public Task<Unit> Handle(TCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(Unit.Value);
        }
    }
}