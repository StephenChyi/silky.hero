using JetBrains.Annotations;
using Silky.Core;
using Silky.Identity.Application.Contracts.Role.Dtos;
using Silky.Organization.Application.Contracts.Organization;
using System.Threading.Tasks;

namespace Silky.Identity.Domain.Extensions;

public static class GetCustomOrganizationOutputExtensions
{
    public static async Task SetOrganizationName([NotNull] this GetCustomOrganizationOutput getCustomOrganizationOutput)
    {
        var organizationAppService = EngineContext.Current.Resolve<IOrganizationAppService>();

        getCustomOrganizationOutput.Name = (await organizationAppService.GetAsync(getCustomOrganizationOutput.OrganizationId))?.Name;
    }
}