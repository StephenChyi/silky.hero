using Silky.EntityFrameworkCore.Repositories;

namespace Silky.WorkFlow.Domain
{
    public class WorkFlowNodeDomainService : IWorkFlowNodeDomainService
    {
        public IRepository<WorkFlowNode> WorkFlowNodeRepository { get; }
        public WorkFlowNodeDomainService(IRepository<WorkFlowNode> workFlowNodeRepository)
        {
            WorkFlowNodeRepository = workFlowNodeRepository;
        }

        public async Task<WorkFlowNode> GetCurrentAsync(long workFlowId, string nodeCode)
        {
            return await WorkFlowNodeRepository.FirstOrDefaultAsync(n => n.WorkFlowId==workFlowId&&n.FlowNodeCode==nodeCode);
        }
    }
}
