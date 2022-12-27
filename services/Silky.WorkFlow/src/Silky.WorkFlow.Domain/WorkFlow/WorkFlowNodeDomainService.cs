using Silky.Core.DbContext.UnitOfWork;
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

        [UnitOfWork]
        public async Task CreateAsync(WorkFlowNode[] workFlowNodes)
        {
            await WorkFlowNodeRepository.InsertAsync(workFlowNodes);
        }
    }
}
