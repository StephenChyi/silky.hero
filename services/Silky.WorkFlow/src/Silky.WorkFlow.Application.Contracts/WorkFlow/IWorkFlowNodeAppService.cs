using Microsoft.AspNetCore.Mvc;
using Silky.Rpc.Routing;
using Silky.Rpc.Runtime.Server;
using Silky.Rpc.Security;
using Silky.WorkFlow.Application.Contracts.WorkFlow.Dtos;

namespace Silky.WorkFlow.Application.Contracts.WorkFlow
{
    [ServiceRoute]
    [Authorize]
    public interface IWorkFlowNodeAppService
    {
        ///// <summary>
        ///// 获取业务工作流
        ///// </summary>
        ///// <param name="id"></param>
        ///// <param name="businessCategoryCode"></param>
        ///// <returns></returns>
        //[HttpGet("{id:long}")]
        //[GetCachingIntercept("id:{id}")]
        //[Authorize]
        //Task<IEnumerable<FlowNodeOutPut>> GetAsync(string businessCategoryCode);

        //[HttpPost]
        //Task Creatsync(FlowNodeInPut[] nodes);
    }
}
