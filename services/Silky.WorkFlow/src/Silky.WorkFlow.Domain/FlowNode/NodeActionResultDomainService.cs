using Microsoft.EntityFrameworkCore;
using Silky.EntityFrameworkCore.Repositories;

namespace Silky.WorkFlow.Domain
{
    public class NodeActionResultDomainService : INodeActionResultDomainService
    {
        public IRepository<NodeActionResult> NodeActionResultRepository { get; }

        public NodeActionResultDomainService(IRepository<NodeActionResult> nodeActionResultRepository)
        {
            NodeActionResultRepository = nodeActionResultRepository;
        }

        public async Task<ICollection<NodeActionResult>> GetPrevNodeActionResultsAsync(long[] prevFlowNodeIds, string businessCategoryCode)
        {
            return await NodeActionResultRepository
                 .AsQueryable(false)
                 .AsNoTracking()
                 .Include(r => r.FlowNode)
                 .Include(r => r.FlowNode.NodeCalculations)
                 .Where(r => r.BusinessCategoryCode == businessCategoryCode && prevFlowNodeIds.Contains(r.PrevFlowNodeId))
                 .ToListAsync();
        }
    }
}
