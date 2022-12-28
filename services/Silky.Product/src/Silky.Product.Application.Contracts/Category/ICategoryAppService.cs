using Microsoft.AspNetCore.Mvc;
using Silky.Product.Application.Contracts.Category.Dtos;
using Silky.Product.Domain.Shared;
using Silky.Rpc.Routing;
using Silky.Rpc.Security;

namespace Silky.Product.Application.Contracts.Category
{
    [ServiceRoute]
    [Authorize]
    public interface ICategoryAppService
    {
        [HttpPost]
        [Authorize]
        Task CreateAsync(CreateCategoryInput input);

        [HttpGet("tree/{categoryType:int}")]
        [Authorize]
        Task<GetCategoryTreeOutput[]> GetCategoryTreeAsync(CategoryType categoryType);

        [HttpGet("fullName/{id:long}")]
        [Authorize]
        Task<GetCategoryOutput> GetFullNameCategoryAsync(long id, [FromQuery] string inseries);
    }
}
