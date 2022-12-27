using Microsoft.EntityFrameworkCore;
using Silky.Core.DbContext.UnitOfWork;
using Silky.EntityFrameworkCore.Repositories;

namespace Silky.WorkFlow.Domain
{
    public class FlowNodeDomainService : IFlowNodeDomainService
    {
        public IRepository<FlowNode> FlowNodeRepository { get; }
        public IRepository<FlowLine> NodeActionResults { get; }
        public IRepository<NodeCalculation> NodeCalculations { get; }

        public FlowNodeDomainService(IRepository<FlowNode> flowNodeRepository, IRepository<FlowLine> nodeActionResults, IRepository<NodeCalculation> nodeCalculations)
        {
            FlowNodeRepository = flowNodeRepository;
            NodeActionResults = nodeActionResults;
            NodeCalculations = nodeCalculations;
        }
    }
}
