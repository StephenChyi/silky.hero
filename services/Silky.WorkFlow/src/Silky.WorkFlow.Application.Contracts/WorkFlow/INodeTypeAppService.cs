using Microsoft.AspNetCore.Mvc;
using Silky.Rpc.Routing;
using Silky.Rpc.Security;
using Silky.WorkFlow.Application.Contracts.WorkFlow.Dtos;

namespace Silky.WorkFlow.Application.Contracts.WorkFlow
{
    [ServiceRoute]
    [Authorize]
    public interface INodeTypeAppService
    {
        [HttpPost]
        Task CreateAsync(CreateNodeTypeInput input);

        [HttpGet]
        Task<ICollection<GetNodeTypeOutput>> GetDicAsync();
    }
}
