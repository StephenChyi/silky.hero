﻿using Silky.Core;
using Silky.Identity.Application.Contracts.User.Dtos;
using Silky.Position.Application.Contracts.Position;
using System.Linq;
using System.Threading.Tasks;

namespace Silky.Identity.Domain.Extensions;

public static class GetOrganizationUserPageOutputExtensions
{
    public static async Task SetPositionInfo(this GetOrganizationUserPageOutput organizationUserOutput, long organizationId)
    {
        var positionAppService = EngineContext.Current.Resolve<IPositionAppService>();
        var userOrganizationPosition = organizationUserOutput.UserSubsidiaries.FirstOrDefault(p => p.OrganizationId == organizationId);
        if (userOrganizationPosition != null)
        {
            organizationUserOutput.PositionId = userOrganizationPosition.PositionId;
            organizationUserOutput.PositionName = (await positionAppService.GetAsync(userOrganizationPosition.PositionId))?.Name;
        }
    }
}
