using Silky.WorkFlow.Application.Contracts.WorkFlow;
using Silky.WorkFlow.Application.Contracts.WorkFlow.Dtos;
using Silky.WorkFlow.Domain;

namespace Silky.WorkFlow.Application.WorkFlow
{
    public class WorkFlowAppService : IWorkFlowAppService
    {
        private readonly IWorkFlowNodeDomainService _workFlowDomainService;
        public WorkFlowAppService(IWorkFlowNodeDomainService workFlowDomainService)
        {
            _workFlowDomainService = workFlowDomainService;
        }

        //public Task<IEnumerable<WorkFlowOutPut>> GetAsync(long id, string businessCategoryCode)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
