using Silky.EntityFrameworkCore.Repositories;

namespace Silky.WorkFlow.Domain
{
    public class FlowLineDomainService : IFlowLineDomainService
    {
        public IRepository<FlowLine> FlowLineRepository { get; }

        public FlowLineDomainService(IRepository<FlowLine> flowLineRepository)
        {
            FlowLineRepository = flowLineRepository;
        }
    }
}
