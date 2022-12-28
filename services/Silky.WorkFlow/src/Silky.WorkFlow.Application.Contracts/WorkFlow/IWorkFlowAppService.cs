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

        [HttpPost]
        [Authorize]
        Task CreateAsync(CreateWorkFlowInput input);

        [HttpGet("{id:long}/{proofId:long}")]
        [Authorize]
        Task<GetWorkFlowOutput> GetWorkFlowAsync(long id, long proofId, [FromQuery] string businessCategoryCode);

        [HttpGet("currentUser/{id:long}/{proofId:long}")]
        [Authorize]
        Task<GetWorkFlowCurrentOutput> GetCurrentAsync(long id, long proofId, [FromQuery] string businessCategoryCode);

        [HttpPut("audit")]
        [Authorize]
        Task AuditAsync(AuditWorkFlowInput audit);

        [HttpGet("logs/{workFlowId:long}")]
        [Authorize]
        Task<GetWorkFlowLogsOutput[]> GetWorkFlowLogsAsync(long workFlowId);
    }
}
