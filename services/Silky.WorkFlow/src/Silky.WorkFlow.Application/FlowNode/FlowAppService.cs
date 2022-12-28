using Mapster;
using Silky.WorkFlow.Application.Contracts.Flow;
using Silky.WorkFlow.Application.Contracts.Flow.Dto;
using Silky.WorkFlow.Domain;

namespace Silky.WorkFlow.Application.Flow
{
    public class FlowAppService : IFlowAppService
    {
        private readonly IFlowDomainService _flowDomainService;
        public FlowAppService(IFlowDomainService flowDomainService)
        {
            _flowDomainService = flowDomainService;
        }

        public Task CreateAsync(CreateFlowInPut flow)
        {
            return _flowDomainService.CreateAsync(flow.Adapt<Domain.Flow>());
        }
    }
}
