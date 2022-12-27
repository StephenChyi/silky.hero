using Microsoft.EntityFrameworkCore;
using Silky.Core.DbContext.UnitOfWork;
using Silky.EntityFrameworkCore.Repositories;

namespace Silky.WorkFlow.Domain
{
    public class FlowNodeDomainService : IFlowNodeDomainService
    {
        public IRepository<FlowNode> FlowNodeRepository { get; }
        public IRepository<NodeActionResult> NodeActionResults { get; }
        public IRepository<NodeCalculation> NodeCalculations { get; }

        public FlowNodeDomainService(IRepository<FlowNode> flowNodeRepository, IRepository<NodeActionResult> nodeActionResults, IRepository<NodeCalculation> nodeCalculations)
        {
            FlowNodeRepository = flowNodeRepository;
            NodeActionResults = nodeActionResults;
            NodeCalculations = nodeCalculations;
        }

        [UnitOfWork]
        public async Task CreateAsync(FlowNode[] flowNodes, NodeActionResult[] nodeActionResults, NodeCalculation[] nodeCalculations)
        {
            await FlowNodeRepository.InsertAsync(flowNodes);
            await NodeActionResults.InsertAsync(nodeActionResults);            
            await NodeCalculations.InsertAsync(nodeCalculations);
        }

        public async Task<FlowNode> GetFlowNodeByIdAsync(long id)
        {
            return await FlowNodeRepository
                 .Include(f => f.NodeCalculations)
                 .FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<FlowNode> GetStartFlowNodeAsync(string businessCategoryCode)
        {
            return await FlowNodeRepository
                   .Include(f => f.NodeCalculations)
                   .FirstOrDefaultAsync(f => f.BusinessCategoryCode == businessCategoryCode && f.StepNo == 0);
        }

        public async Task<ICollection<long>> GetFlowNodeIdsAsync(string businessCategoryCode)
        {
            return await FlowNodeRepository.AsQueryable(false).Where(f => f.BusinessCategoryCode == businessCategoryCode).Select(f => f.Id).ToListAsync();
        }

        public async Task<ICollection<FlowNode>> GetFlowNodesByIdsAsync(long[] ids, string businessCategoryCode)
        {
            return await FlowNodeRepository.AsQueryable(false).AsNoTracking().Where(f => ids.Contains(f.Id) && f.BusinessCategoryCode == businessCategoryCode).ToListAsync();
        }
    }
}
