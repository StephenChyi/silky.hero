using Silky.EntityFrameworkCore.Repositories;

namespace Silky.WorkFlow.Domain
{
    public class FlowNodeDomainService : IFlowNodeDomainService
    {
        public IRepository<FlowNode> FlowNodeRepository { get; }

        public FlowNodeDomainService(IRepository<FlowNode> flowNodeRepository)
        {
            FlowNodeRepository = flowNodeRepository;
        }
    }
}
