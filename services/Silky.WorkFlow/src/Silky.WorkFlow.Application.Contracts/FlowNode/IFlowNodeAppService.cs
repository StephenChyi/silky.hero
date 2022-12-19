using Microsoft.AspNetCore.Mvc;
using Silky.Rpc.Routing;
using Silky.Rpc.Security;
using Silky.WorkFlow.Application.Contracts.FlowNode.Dto;

namespace Silky.WorkFlow.Application.Contracts.FlowNode
{
    [ServiceRoute]
    [Authorize]
    public interface IFlowNodeAppService
    {
        /// <summary>
        /// 获取业务工作流
        /// </summary>
        /// <param name="id"></param>
        /// <param name="businessCategoryCode"></param>
        /// <returns></returns>
        [HttpGet("businessflow")]
        [Authorize]
        Task<GetFlowNodeOutPut> GetBusinessFlowAsync([FromQuery] string businessCategoryCode);

        [HttpPost]
        Task CreateAsync(CreateFlowNodeInPut flowNode);
    }
}
