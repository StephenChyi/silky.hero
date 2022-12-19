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
        /// <summary>
        /// 获取单据工作流(具体到某一单据)
        /// </summary>
        /// <param name="id"></param>
        /// <param name="businessCategoryCode"></param>
        /// <returns></returns>
        //[HttpGet("{id:long}/{businessCategoryCode:string}")]
        //[Authorize]
        //Task<IEnumerable<WorkFlowOutPut>> GetAsync(long id, string businessCategoryCode);
    }
}
