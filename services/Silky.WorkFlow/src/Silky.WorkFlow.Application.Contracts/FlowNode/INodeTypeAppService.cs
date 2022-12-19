using Microsoft.AspNetCore.Mvc;
using Silky.Rpc.Routing;
using Silky.Rpc.Security;
using Silky.WorkFlow.Application.Contracts.FlowNode.Dto;

namespace Silky.WorkFlow.Application.Contracts.FlowNode
{
    [ServiceRoute]
    [Authorize]
    public interface INodeTypeAppService
    {
        [HttpPost]
        [Authorize]
        Task CreateAsync(CreateNodeTypeInput input);

        [HttpGet]
        Task<ICollection<GetNodeTypeOutput>> GetDicAsync();
    }
}
