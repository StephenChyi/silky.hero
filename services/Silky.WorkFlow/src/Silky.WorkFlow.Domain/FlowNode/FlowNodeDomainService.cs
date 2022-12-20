using Microsoft.EntityFrameworkCore;
using Silky.Core.DbContext.UnitOfWork;
using Silky.EntityFrameworkCore.Repositories;

namespace Silky.WorkFlow.Domain
{
    public class FlowNodeDomainService : IFlowNodeDomainService
    {
        public IRepository<FlowNode> FlowNodeRepository { get; }
        public IRepository<NodeActionResult> NodeActionResults { get; }

        public FlowNodeDomainService(IRepository<FlowNode> flowNodeRepository, IRepository<NodeActionResult> nodeActionResults)
        {
            FlowNodeRepository = flowNodeRepository;
            NodeActionResults = nodeActionResults;
        }

        [UnitOfWork]
        public async Task CreateAsync(FlowNode[] flowNodes, NodeActionResult[] nodeActionResults)
        {
            await FlowNodeRepository.InsertAsync(flowNodes);
            await NodeActionResults.InsertAsync(nodeActionResults);
        }

        public async Task<ICollection<FlowNode>> GetFlowNodesAsync(string businessCategoryCode)
        {
            return await FlowNodeRepository
                 .AsQueryable(false)
                 .AsNoTracking()
                 .Include(f => f.NodeType)
                 .Include(f => f.NextNodes)
                 .Where(f => f.BusinessCategoryCode == businessCategoryCode || f.Id == 0)
                 .OrderBy(f => f.StepNo)
                 .ToListAsync();
        }
    }
}
