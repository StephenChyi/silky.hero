using Mapster;
using Microsoft.EntityFrameworkCore;
using Silky.Core.DbContext.UnitOfWork;
using Silky.EntityFrameworkCore.Repositories;
using Silky.WorkFlow.Domain.Shared;

namespace Silky.WorkFlow.Domain
{
    public class WorkFlowNodeDomainService : IWorkFlowNodeDomainService
    {
        public IRepository<WorkFlowNode> WorkFlowNodeRepository { get; }

        public WorkFlowNodeDomainService(IRepository<WorkFlowNode> workFlowRepository)
        {
            WorkFlowNodeRepository = workFlowRepository;
        }

        [UnitOfWork]
        public async Task CreateAsync(WorkFlowNode[] workFlowNodes)
        {
            await WorkFlowNodeRepository.InsertAsync(workFlowNodes);
        }

        public async Task<ICollection<WorkFlowNode>> GetWorkFlowNodesAsync(long proofId, string businessCategoryCode)
        {
            return await WorkFlowNodeRepository
                .AsQueryable(false)
                .AsNoTracking()
                .Include(w => w.NextFlowNodes)
                .Include(w => w.NodeType)
                .Where(w => w.ProofId == proofId && w.BusinessCategoryCode == businessCategoryCode)
                .OrderBy(w => w.StepNo)
                .ToListAsync();
        }
    }
}
