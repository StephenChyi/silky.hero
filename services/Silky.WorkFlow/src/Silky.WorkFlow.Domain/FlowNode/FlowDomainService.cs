using Silky.Core.DbContext.UnitOfWork;
using Silky.EntityFrameworkCore.Repositories;

namespace Silky.WorkFlow.Domain
{
    public class FlowDomainService : IFlowDomainService
    {
        public IRepository<Flow> FlowRepository { get; }
        public IRepository<FlowNode> FlowNodeRepository { get; }
        public IRepository<FlowLine> FlowLineResults { get; }
        public IRepository<NodeCalculation> NodeCalculations { get; }

        public FlowDomainService(IRepository<Flow> flowRepository, IRepository<FlowNode> flowNodeRepository, IRepository<FlowLine> flowLineResults, IRepository<NodeCalculation> nodeCalculations)
        {
            FlowRepository = flowRepository;
            FlowNodeRepository = flowNodeRepository;
            FlowLineResults = flowLineResults;
            NodeCalculations = nodeCalculations;
        }

        [UnitOfWork]
        public async Task CreateFlowAsync(Flow flow)
        {
            await FlowRepository.InsertAsync(flow);
        }

        public Task<Flow> GetFlowAsync(string businessCategoryCode)
        {
            throw new NotImplementedException();
        }
    }
}
