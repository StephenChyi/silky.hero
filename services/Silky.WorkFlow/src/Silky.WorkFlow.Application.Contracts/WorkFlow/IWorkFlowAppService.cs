using Microsoft.AspNetCore.Mvc;
using Silky.Rpc.Routing;
using Silky.Rpc.Security;
using Silky.WorkFlow.Application.Contracts.WorkFlow.Dtos;

namespace Silky.WorkFlow.Application.Contracts.WorkFlow
{
    [ServiceRoute]
    [Authorize]
    public interface IWorkFlowAppService
    {

        [HttpPost("{proofId:long}")]
        [Authorize]
        Task CreateAsync(long proofId, [FromQuery] string businessCategoryCode);


        [HttpGet("workflow/{proofId:long}")]
        [Authorize]
        Task<GetWorkFlowOutPut> GetWorkFlowAsync(long proofId, [FromQuery] string businessCategoryCode);
    }
}
