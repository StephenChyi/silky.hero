using Microsoft.AspNetCore.Mvc;
using Silky.Rpc.Routing;
using Silky.Rpc.Security;
using Silky.WorkFlow.Application.Contracts.Flow.Dto;

namespace Silky.WorkFlow.Application.Contracts.Flow
{
    [ServiceRoute]
    [Authorize]
    public interface IFlowAppService
    {
        [HttpPost]
        Task CreateAsync(CreateFlowInPut flowNode);
    }
}
