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

        public async Task<FlowNode> GetStartFlowNodesAsync(string businessCategoryCode)
        {
            return await FlowNodeRepository.FirstOrDefaultAsync(f => f.BusinessCategoryCode == businessCategoryCode && f.StepNo == 0);
        }

        public async Task<ICollection<long>> GetFlowNodeIdsAsync(string businessCategoryCode)
        {
            return await FlowNodeRepository.AsQueryable(false).Where(f => f.BusinessCategoryCode == businessCategoryCode).Select(f => f.Id).ToListAsync();
        }

        public async Task<ICollection<FlowNode>> GetFlowNodeByIdsAsync(long[] ids, string businessCategoryCode)
        {
            return await FlowNodeRepository.AsQueryable(false).AsNoTracking().Where(f => ids.Contains(f.Id) && f.BusinessCategoryCode == businessCategoryCode).ToListAsync();
        }
    }
}
