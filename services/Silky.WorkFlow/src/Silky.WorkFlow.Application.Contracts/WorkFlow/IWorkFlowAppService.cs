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

        [HttpGet("{id:long}/{proofId:long}")]
        [Authorize]
        Task<GetWorkFlowOutPut> GetWorkFlowAsync(long id, long proofId, [FromQuery] string businessCategoryCode);

        [HttpGet("currentUser/{id:long}/{proofId:long}")]
        [Authorize]
        Task<GetWorkFlowCurrentOutPut> GetCurrentAsync(long id, long proofId, [FromQuery] string businessCategoryCode);

        [HttpPut("audit")]
        [Authorize]
        Task AuditAsync(AuditWorkFlowInput audit);
    }
}
