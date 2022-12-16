using Silky.EntityFrameworkCore.Repositories;

namespace Silky.WorkFlow.Domain
{
    public class WorkFlowNodeDomainService : IWorkFlowNodeDomainService
    {
        public IRepository<WorkFlowNode> WorkFlowNodeRepository { get; }

        public WorkFlowNodeDomainService(IRepository<WorkFlowNode> workFlowRepository)
        {
            WorkFlowNodeRepository = workFlowRepository;
        }
    }
}
