using Microsoft.AspNetCore.Mvc;
using Silky.Rpc.Routing;
using Silky.Rpc.Runtime.Server;
using Silky.Rpc.Security;

namespace Silky.WorkFlow.Application.Contracts.BusinessCategory
{
    [ServiceRoute]
    [Authorize]
    public interface IBusinessCategoryAppService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:long}")]
        [GetCachingIntercept("id:{id}")]
        [Authorize]
        Task<long> GetAsync(long id);
    }
}