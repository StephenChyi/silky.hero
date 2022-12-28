using Microsoft.EntityFrameworkCore;
using Silky.EntityFrameworkCore.Repositories;
using Silky.WorkFlow.Domain.Shared;

namespace Silky.WorkFlow.Domain
{
    public class WorkFlowLineDomainService : IWorkFlowLineDomainService
    {
        public IRepository<WorkFlowLine> WorkFlowLineRepository { get; }
        public WorkFlowLineDomainService(IRepository<WorkFlowLine> workFlowLineRepository)
        {
            WorkFlowLineRepository = workFlowLineRepository;
        }
        public async Task<ICollection<WorkFlowLine>> GetLinesByCurrentAsync(long workFlowId, string workFlowNodeCode)
        {
            return await WorkFlowLineRepository.AsQueryable(false).Where(l => l.WorkFlowId == workFlowId && l.WorkFlowNodeCode == workFlowNodeCode).ToListAsync();
        }

        public async Task<WorkFlowLine> GetNextNodeCodeAsync(long workFlowId, string workFlowNodeCode, ActionType actionType)
        {
            return await WorkFlowLineRepository.FirstOrDefaultAsync(l => l.WorkFlowId == workFlowId && l.PrevWorkFlowNodeCode == workFlowNodeCode && l.ActionType == actionType);
        }
    }
}
