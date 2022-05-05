using OT.Application.Interfaces.UnitOfWorks;

namespace OT.Application.Features.DependencyInjection
{
    public class UnitOfWorkDependencyInjection
    {
        public UnitOfWorkDependencyInjection(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
        protected IUnitOfWork UnitOfWork { get; }

    }
}