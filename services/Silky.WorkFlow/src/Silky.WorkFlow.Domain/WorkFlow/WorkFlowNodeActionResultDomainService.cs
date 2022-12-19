using Silky.EntityFrameworkCore.Repositories;

namespace Silky.WorkFlow.Domain
{
    public class WorkFlowNodeActionResultDomainService : IWorkFlowNodeActionResultDomainService
    {
        public IRepository<WorkFlowNodeActionResult> WorkFlowNodeActionResultRepository { get; }

        public WorkFlowNodeActionResultDomainService(IRepository<WorkFlowNodeActionResult> workFlowNodeActionResultRepository)
        {
            WorkFlowNodeActionResultRepository = workFlowNodeActionResultRepository;
        }
    }
}
