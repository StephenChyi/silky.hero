using Microsoft.EntityFrameworkCore;
using Silky.Core.DbContext.UnitOfWork;
using Silky.EntityFrameworkCore.Repositories;

namespace Silky.WorkFlow.Domain
{
    public class WorkFlowDomainService : IWorkFlowDomainService
    {
        public IRepository<WorkFlow> WorkFlowRepository { get; }
        public IRepository<WorkFlowLog> WorkFlowLogRepository { get; }
        public IRepository<WorkFlowHistory> WorkFlowHistoryRepository { get; }
        public WorkFlowDomainService(IRepository<WorkFlow> workFlowRepository, IRepository<WorkFlowLog> workFlowLogRepository, IRepository<WorkFlowHistory> workFlowHistoryRepository)
        {
            WorkFlowRepository = workFlowRepository;
            WorkFlowLogRepository = workFlowLogRepository;
            WorkFlowHistoryRepository = workFlowHistoryRepository;
        }

        [UnitOfWork]
        public async Task CreateAsync(WorkFlow workFlow)
        {
            await WorkFlowRepository.InsertAsync(workFlow);
        }

        public Task<WorkFlow> GetAsync(long id, long proofId, string businessCategoryCode)
        {
            return WorkFlowRepository
                 .Include(w => w.WorkFlowNodes)
                 .Include(w => w.WorkFlowLines)
                 .Include(w => w.WorkFlowLogs)
                 .AsNoTracking()
                 .FirstOrDefaultAsync(w => w.Id == id && w.ProofId == proofId && w.BusinessCategoryCode == businessCategoryCode);
        }

        public Task<WorkFlow> GetCurrentAsync(long id, long proofId, string businessCategoryCode)
        {
            return WorkFlowRepository
                .AsQueryable(false)
                .IgnoreAutoIncludes()
                .FirstOrDefaultAsync(w => w.Id == id && w.ProofId == proofId && w.BusinessCategoryCode == businessCategoryCode);
        }

        [UnitOfWork]
        public async Task AuditAsync(WorkFlow workFlow, WorkFlowLog log, WorkFlowHistory history)
        {
            await WorkFlowRepository.UpdateAsync(workFlow);
            await WorkFlowLogRepository.InsertAsync(log);
            await WorkFlowHistoryRepository.InsertAsync(history);
        }
    }
}
