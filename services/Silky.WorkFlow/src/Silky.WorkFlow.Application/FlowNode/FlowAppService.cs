using Mapster;
using Silky.WorkFlow.Application.Contracts.Flow;
using Silky.WorkFlow.Application.Contracts.Flow.Dto;

namespace Silky.WorkFlow.Application.Flow
{
    public class FlowAppService : IFlowAppService
    {

        public FlowAppService()
        {

        }

        public Task CreateAsync(CreateFlowInPut flow)
        {
            var entity = flow.Adapt<Domain.Flow>();





            return null;
        }
    }
}
