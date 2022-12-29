using Microsoft.AspNetCore.Mvc;
using Silky.Hero.Common.Enums;
using Silky.Product.Application.Contracts.SKU.Dtos;
using Silky.Rpc.Routing;
using Silky.Rpc.Security;

namespace Silky.Product.Application.Contracts.SKU
{
    [ServiceRoute]
    [Authorize]
    public interface IAttributeAppService
    {
        [HttpPost("key")]
        [Authorize]
        Task CreateKeyAsync(CreateAttributeKeyInput input);

        [HttpPost("value")]
        [Authorize]
        Task CreateValueAsync(CreateAttributeValueInput input);

        [HttpGet]
        [Authorize]
        Task<GetAttributeOutput[]> GetAttributesAsync(long categoryId, Status Status);
    }
}
