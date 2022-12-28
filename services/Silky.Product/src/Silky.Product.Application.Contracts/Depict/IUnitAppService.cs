using Microsoft.AspNetCore.Mvc;
using Silky.Product.Application.Contracts.Depict.Dtos;
using Silky.Rpc.Routing;
using Silky.Rpc.Security;

namespace Silky.Product.Application.Contracts.Depict
{
    [ServiceRoute]
    [Authorize]
    public interface IUnitAppService
    {
        [HttpPost]
        [Authorize]
        Task CreateAsync(CreateUnitInput input);

        [HttpGet]
        [Authorize]
        string[] GetUnits([FromQuery] string name);

        [HttpDelete]
        [Authorize]
        Task ClearAsync();
    }
}
