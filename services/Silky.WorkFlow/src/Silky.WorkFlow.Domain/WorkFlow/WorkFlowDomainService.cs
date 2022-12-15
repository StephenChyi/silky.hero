using Silky.EntityFrameworkCore.Repositories;

namespace Silky.WorkFlow.Domain
{
    public class WorkFlowDomainService : IWorkFlowDomainService
    {
        public IRepository<WorkFlow> WorkFlowRepository { get; }

        public WorkFlowDomainService(IRepository<WorkFlow> workFlowRepository)
        {
            WorkFlowRepository = workFlowRepository;
        }
    }
}
