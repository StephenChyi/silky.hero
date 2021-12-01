﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Castle.Core.Internal;
using Mapster;
using Silky.Core.Exceptions;
using Silky.EntityFrameworkCore.Extensions;
using Silky.Organization.Application.Contracts.Organization;
using Silky.Organization.Application.Contracts.Organization.Dtos;
using Silky.Organization.Domain.Organizations;

namespace Silky.Organization.Application.Organization;

public class OrganizationAppService : IOrganizationAppService
{
    private readonly IOrganizationDomainService _organizationDomainService;

    public OrganizationAppService(IOrganizationDomainService organizationDomainService)
    {
        _organizationDomainService = organizationDomainService;
    }

    public Task CreateOrUpdateAsync(CreateOrUpdateOrganizationInput input)
    {
        if (!input.Id.HasValue)
        {
            return _organizationDomainService.CreateAsync(input);
        }

        return _organizationDomainService.UpdateAsync(input);
    }

    public Task DeleteAsync(long id)
    {
        return _organizationDomainService.DeleteAsync(id);
    }

    public async Task<GetOrganizationOutput> GetAsync(long id)
    {
        var organization = await _organizationDomainService.OrganizationRepository.FindOrDefaultAsync(id);
        if (organization == null)
        {
            throw new UserFriendlyException($"不存在Id为{id}的组织机构");
        }

        return organization.Adapt<GetOrganizationOutput>();
    }

    public async Task<PagedList<GetOrganizationPageOutput>> GetPageAsync(GetOrganizationPageInput input)
    {
        var organizations = await _organizationDomainService.OrganizationRepository
            .Where(input.Id.HasValue, o => o.Id == input.Id || o.ParentId == input.Id)
            .Where(!input.Name.IsNullOrEmpty(), o => o.Name.Contains(input.Name))
            .Where(input.Status.HasValue, o => o.Status == input.Status)
            .OrderByDescending(p=> p.Sort)
            .ProjectToType<GetOrganizationPageOutput>()
            .ToPagedListAsync(input.PageIndex, input.PageSize);
        return organizations;
    }

    public async Task<ICollection<GetOrganizationTreeOutput>> GetTreeAsync()
    {
        var organizations = await _organizationDomainService.GetTreeAsync();
        return organizations;
    }
}