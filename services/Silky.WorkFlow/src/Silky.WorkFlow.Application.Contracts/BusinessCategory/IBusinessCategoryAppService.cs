using Microsoft.AspNetCore.Mvc;
using Silky.Rpc.Routing;
using Silky.Rpc.Security;
using Silky.WorkFlow.Application.Contracts.BusinessCategory.Dto;

namespace Silky.WorkFlow.Application.Contracts.BusinessCategory
{
    [ServiceRoute]
    [Authorize]
    public interface IBusinessCategoryAppService
    {
        [HttpGet("{id:long}")]
        Task<GetBusinessCategoryOutPut> GetAsync(long id);

        [HttpGet]
        Task<ICollection<GetBusinessCategoryOutPut>> GetBusinessCategoriesAsync();

        [HttpPost]
        Task CreateAsync(CreateBusinessCategoryInPut input);
    }
}