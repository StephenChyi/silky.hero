using Microsoft.EntityFrameworkCore;
using Silky.EntityFrameworkCore.Repositories;

namespace Silky.WorkFlow.Domain
{
    public class WorkFlowLogDomainService : IWorkFlowLogDomainService
    {
        public IRepository<WorkFlowLog> WorkFlowLogRepository { get; }
        public WorkFlowLogDomainService(IRepository<WorkFlowLog> workFlowLogRepository)
        {
            WorkFlowLogRepository = workFlowLogRepository;
        }

        public async Task<ICollection<WorkFlowLog>> GetWorkFlowLogsAsync(long workFlowId)
        {
            return await WorkFlowLogRepository
                .AsQueryable(false)
                .Where(l => l.WorkFlowId == workFlowId)
                .OrderBy(l => l.CreatedTime)
                .ToListAsync();
        }
    }
}
