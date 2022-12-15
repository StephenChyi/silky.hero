﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Silky.Account.Application.Contracts.Account.Dtos;
using Silky.Core;
using Silky.Core.Exceptions;
using Silky.Core.Extensions;
using Silky.Core.Runtime.Session;
using Silky.EntityFrameworkCore.Extensions;
using Silky.EntityFrameworkCore.Extras;
using Silky.EntityFrameworkCore.Repositories;
using Silky.Hero.Common.Enums;
using Silky.Hero.Common.Session;
using Silky.Identity.Application.Contracts.Role.Dtos;
using Silky.Identity.Application.Contracts.User.Dtos;
using Silky.Identity.Domain.Extensions;
using Silky.Identity.Domain.Shared;
using Silky.Organization.Application.Contracts.Organization;
using Silky.Permission.Application.Contracts.Menu;
using Silky.Position.Application.Contracts.Position;
using Silky.Saas.Application.Contracts.Edition;
using Silky.Saas.Domain.Shared.Feature;

namespace Silky.Identity.Domain;

public class IdentityUserManager : UserManager<IdentityUser>
{
    public IIdentityUserRepository UserRepository { get; }

    public IIdentityRoleRepository RoleRepository { get; }

    public IRepository<UserSubsidiary> UserSubsidiaryRepository { get; }
    public IRepository<IdentityUserClaim> UserClaimRepository { get; }
    public IRepository<IdentityClaimType> ClaimTypeRepository { get; }
    public IRepository<IdentityRoleOrganization> RoleOrganizationRepository { get; }

    private readonly IRepository<IdentityRoleMenu> _roleMenuRepository;
    private readonly IOrganizationAppService _organizationAppService;
    private readonly IPositionAppService _positionAppService;
    private readonly IMenuAppService _menuAppService;
    private readonly IEditionAppService _editionAppService;
    private readonly ISession _session;

    public IdentityUserManager(IdentityUserStore store,
        IOptions<IdentityOptions> optionsAccessor,
        IPasswordHasher<IdentityUser> passwordHasher,
        IEnumerable<IUserValidator<IdentityUser>> userValidators,
        IEnumerable<IPasswordValidator<IdentityUser>> passwordValidators,
        ILookupNormalizer keyNormalizer,
        IdentityErrorDescriber errors,
        IServiceProvider services,
        ILogger<IdentityUserManager> logger,
        IRepository<UserSubsidiary> userSubsidiaryRepository,
        IIdentityUserRepository userRepository,
        IOrganizationAppService organizationAppService,
        IPositionAppService positionAppService,
        IRepository<IdentityUserClaim> userClaimRepository,
        IRepository<IdentityClaimType> claimTypeRepository,
        IRepository<IdentityRoleOrganization> roleOrganizationRepository,
        IRepository<IdentityRoleMenu> roleMenuRepository,
        IMenuAppService menuAppService,
        IEditionAppService editionAppService,
        IIdentityRoleRepository roleRepository)
        : base(store,
            optionsAccessor,
            passwordHasher,
            userValidators,
            passwordValidators,
            keyNormalizer,
            errors,
            services,
            logger)
    {
        UserSubsidiaryRepository = userSubsidiaryRepository;
        UserRepository = userRepository;
        _organizationAppService = organizationAppService;
        _positionAppService = positionAppService;
        UserClaimRepository = userClaimRepository;
        ClaimTypeRepository = claimTypeRepository;
        RoleOrganizationRepository = roleOrganizationRepository;
        RoleRepository = roleRepository;
        _roleMenuRepository = roleMenuRepository;
        _menuAppService = menuAppService;
        _editionAppService = editionAppService;
        _session = NullSession.Instance;
    }

    public async Task<string[]> GetUserPermissionCodesAsync(long userId)
    {
        // 1. 获取用户的角色信息
        var userRoleIds = await UserRepository.GetRolesAsync(userId).Select(p => p.Id).ToListAsync();
        // 2. 获取角色的菜单信息
        var roleMenuIds = await _roleMenuRepository
            .AsQueryable(false)
            .Where(p => userRoleIds.Contains(p.RoleId))
            .Select(p => p.MenuId)
            .Distinct()
            .ToArrayAsync();
        // 3. 获取所有菜单的父级信息
        var menus = await _menuAppService.GetMenusAsync(roleMenuIds);
        return menus.Where(p => !p.PermissionCode.IsNullOrEmpty() && p.Status == Status.Valid)
            .Select(p => p.PermissionCode).ToArray();
    }

    public async Task<ICollection<GetCurrentUserMenuOutput>> GetUserMenusAsync(long userId)
    {
        // 1. 获取用户的角色信息
        var userRoleIds = await UserRepository.GetRolesAsync(userId).Select(p => p.Id).ToListAsync();
        // 2. 获取角色的菜单信息
        var roleMenuIds = await _roleMenuRepository
            .AsQueryable(false)
            .Where(p => userRoleIds.Contains(p.RoleId))
            .Select(p => p.MenuId)
            .Distinct()
            .ToArrayAsync();
        // 3. 获取所有菜单的父级信息
        var menus = await _menuAppService.GetMenusAsync(roleMenuIds);
        // 4. 构建菜单
        var frontendMenus = menus.MapFrontendMenus();
        // 5. 构建树
        return frontendMenus.BuildTree().Adapt<ICollection<GetCurrentUserMenuOutput>>();
    }


    public async Task<IdentityUser> GetByIdAsync(long id)
    {
        var user = await Store.FindByIdAsync(id.ToString(), CancellationToken);
        if (user == null)
        {
            throw new EntityNotFoundException(typeof(IdentityUser), id);
        }

        return user;
    }


    public async Task<IdentityResult> SetUserOrganizations(IdentityUser user,
        params UserSubsidiary[] userSubsidiaries)
    {
        Check.NotNull(user, nameof(user));
        Check.NotNull(userSubsidiaries, nameof(userSubsidiaries));

        var userOrganizationGroup = userSubsidiaries.GroupBy(p => p.OrganizationId)
            .Select(p => new { OrganizationId = p.Key, Count = p.ToArray().Length }).Where(p => p.Count > 1)
            .ToArray();
        if (userOrganizationGroup.Any())
        {
            return IdentityResult.Failed(new IdentityError()
            {
                Code = "OrganizationRepeat",
                Description = "用户所在部门不允许重复"
            });
        }

        foreach (var userSubsidiary in userSubsidiaries)
        {
            if (!await _organizationAppService.HasOrganizationAsync(userSubsidiary.OrganizationId))
            {
                return IdentityResult.Failed(new IdentityError()
                {
                    Code = "NoOrganization",
                    Description = $"不存在Id为{userSubsidiary.OrganizationId}的组织机构"
                });
            }

            if (!await _positionAppService.HasPositionAsync(userSubsidiary.PositionId))
            {
                return IdentityResult.Failed(new IdentityError()
                {
                    Code = "NoPosition",
                    Description = $"不存在Id为{userSubsidiary.PositionId}的职位信息"
                });
            }
        }

        var currentUserSubsidiaries = await GetUserOrganizationsAsync(user);

        var result =
            await RemoveFromUserSubsidiariesAsync(user, currentUserSubsidiaries.Except(userSubsidiaries).Distinct());
        if (!result.Succeeded)
        {
            return result;
        }

        result = await AddToUserSubsidiariesAsync(user,
            userSubsidiaries.Except(currentUserSubsidiaries).Distinct().ToArray());
        if (!result.Succeeded)
        {
            return result;
        }

        return result;
    }

    public async Task<IdentityResult> SetRolesAsync(IdentityUser user, IEnumerable<string> roleNames)
    {
        Check.NotNull(user, nameof(user));
        Check.NotNull(roleNames, nameof(roleNames));
        var currentRoleNames = await GetRolesAsync(user);
        var result = await RemoveFromRolesAsync(user, currentRoleNames.Except(roleNames).Distinct());
        if (!result.Succeeded)
        {
            return result;
        }

        result = await AddToRolesAsync(user, roleNames.Except(currentRoleNames).Distinct());
        if (!result.Succeeded)
        {
            return result;
        }

        return IdentityResult.Success;
    }


    private async Task<IEnumerable<UserSubsidiary>> GetUserOrganizationsAsync(IdentityUser user)
    {
        var userSubsidiaries = UserSubsidiaryRepository
            .AsQueryable(false)
            .Where(p => p.UserId == user.Id);
        return await userSubsidiaries.ToListAsync();
    }

    public async Task<IdentityResult> AddToUserSubsidiariesAsync(IdentityUser user,
        params UserSubsidiary[] userSubsidiaries)
    {
        var currentUserDataRange = await _session.GetCurrentUserDataRangeAsync();
        if (!currentUserDataRange.IsAllData && !userSubsidiaries.Any())
        {
            return IdentityResult.Failed(new IdentityError()
            {
                Code = "NoAuth",
                Description = "请选择用户的部门信息"
            });
        }

        foreach (var userSubsidiary in userSubsidiaries)
        {
            if (user.IsInUserOrganization(userSubsidiary.OrganizationId))
            {
                return IdentityResult.Failed(new IdentityError()
                {
                    Code = "OrganizationRepeat",
                    Description = "用户已存在该部门，不允许重复添加"
                });
            }

            if (userSubsidiary.IsLeader)
            {
                var hasOrganizationLeader = await UserSubsidiaryRepository.AnyAsync(p =>
                    p.OrganizationId == userSubsidiary.OrganizationId && p.IsLeader && p.UserId != userSubsidiary.UserId);
                if (hasOrganizationLeader)
                {
                    return IdentityResult.Failed(new IdentityError()
                    {
                        Code = "HasOrganizationLeader",
                        Description = "该部门已经存在领导"
                    });
                }
            }

            if (!currentUserDataRange.IsAllData &&
                currentUserDataRange.OrganizationIds.All(p => p != userSubsidiary.OrganizationId))
            {
                var organization = await _organizationAppService.GetAsync(userSubsidiary.OrganizationId);
                return IdentityResult.Failed(new IdentityError()
                {
                    Code = "NoAuth",
                    Description = $"您没有新增/修改【{organization.Name}】机构用户的权限"
                });
            }

            user.AddUserSubsidiaries(userSubsidiary.OrganizationId, userSubsidiary.PositionId, userSubsidiary.IsLeader);
        }

        return IdentityResult.Success;
    }

    private async Task<IdentityResult> RemoveFromUserSubsidiariesAsync(IdentityUser user,
        IEnumerable<UserSubsidiary> userSubsidiaries)
    {
        foreach (var userSubsidiary in userSubsidiaries)
        {
            user.RemoveUserSubsidiaries(userSubsidiary.OrganizationId, userSubsidiary.PositionId);
        }

        return IdentityResult.Success;
    }

    public Task<IdentityUser> FindByPhoneNumberAsync(string phoneNumber)
    {
        return ((IdentityUserStore)Store).FindByPhoneNumberAsync(phoneNumber);
    }

    public Task<IdentityUser> FindByAccountAsync(string account, long? tenantId, bool includeDetails = false)
    {
        ThrowIfDisposed();
        if (account == null)
        {
            throw new ArgumentNullException(nameof(account));
        }

        account = NormalizeName(account);
        return ((IdentityUserStore)Store).FindByAccountAsync(account, tenantId, includeDetails);
    }

    public override async Task<IdentityResult> RemovePasswordAsync(IdentityUser user)
    {
        ThrowIfDisposed();
        if (user == null)
            throw new ArgumentNullException(nameof(user));
        var identityResult = await UpdatePasswordHash(user, null, false);
        return identityResult;
    }


    public async Task<IdentityUser> GetByIdAsync(long userId, bool includeDetails)
    {
        if (!includeDetails)
        {
            return await GetByIdAsync(userId);
        }

        return await UserRepository
            .AsQueryable(false)
            .Include(p => p.Claims)
            .Include(p => p.Logins)
            .Include(p => p.Roles)
            .Include(p => p.Tokens)
            .Include(p => p.UserSubsidiaries)
            .FirstOrDefaultAsync(p => p.Id == userId);
    }

    public async Task<PagedList<GetUserPageOutput>> GetPageAsync(GetUserPageInput input)
    {
        var currentUserDataRange = await _session.GetCurrentUserDataRangeAsync();
        var userPage = await UserRepository
            .AsQueryable(false)
            .Include(p => p.UserSubsidiaries)
            .Include(p => p.Roles)
            .Where(!currentUserDataRange.IsAllData,
                p => p.UserSubsidiaries.Any(q => currentUserDataRange.OrganizationIds.Contains(q.OrganizationId)))
            .Where(!input.UserName.IsNullOrEmpty(), p => p.UserName.Contains(input.UserName))
            .Where(!input.Email.IsNullOrEmpty(), p => p.Email.Contains(input.Email))
            .Where(!input.MobilePhone.IsNullOrEmpty(), p => p.MobilePhone.Contains(input.MobilePhone))
            .Where(!input.TelPhone.IsNullOrEmpty(), p => p.TelPhone.Contains(input.TelPhone))
            .Where(!input.JobNumber.IsNullOrEmpty(), p => p.JobNumber.Contains(input.JobNumber))
            .Where(!input.RealName.IsNullOrEmpty(), p => p.RealName.Contains(input.RealName))
            .Where(input.Sex.HasValue, p => p.Sex == input.Sex)
            .Where(input.Status.HasValue, p => p.Status == input.Status)
            .Where(input.IsLeader == true, p => p.UserSubsidiaries.Any(q => q.IsLeader))
            .Where(input.IsLeader == false, p => p.UserSubsidiaries.All(q => q.IsLeader == false))
            .Where(input.IsLockout == true, p => p.LockoutEnd >= DateTimeOffset.Now)
            .Where(input.IsLockout == false, p => p.LockoutEnd < DateTimeOffset.Now || p.LockoutEnd == null)
            .Where(input.OrganizationIds != null && input.OrganizationIds.Any(),
                p => p.UserSubsidiaries.Any(q => input.OrganizationIds.Contains(q.OrganizationId)))
            .Where(input.PositionIds != null && input.PositionIds.Any(),
                p => p.UserSubsidiaries.Any(q => input.PositionIds.Contains(q.PositionId)))
            .Where(input.RoleIds != null && input.RoleIds.Any(),
                p => p.Roles.Any(q => input.RoleIds.Contains(q.RoleId)))
            .OrderByDescending(p => p.CreatedTime)
            .ToPagedListAsync(input.PageIndex, input.PageSize);
        var userPageOutput = userPage.Adapt<PagedList<GetUserPageOutput>>();
        await userPageOutput.Items.SetUserSubsidiaries();
        await userPageOutput.Items.SetUserRoles();
        return userPageOutput;
    }

    public async Task<PagedList<GetAddOrganizationUserPageOutput>> GetAddOrganizationUserPageAsync(long organizationId,
        GetAddOrganizationUserPageInput input)
    {
        var userPage = await UserRepository
            .AsQueryable(false)
            .Include(p => p.UserSubsidiaries)
            .Where(!input.UserName.IsNullOrEmpty(), p => p.UserName.Contains(input.UserName))
            .Where(!input.RealName.IsNullOrEmpty(), p => p.RealName.Contains(input.RealName))
            .OrderByDescending(p => p.CreatedTime)
            .ToPagedListAsync(input.PageIndex, input.PageSize);

        var pageOutput = userPage.Adapt<PagedList<GetAddOrganizationUserPageOutput>>();
        foreach (var organizationUser in pageOutput.Items)
        {
            await organizationUser.SetPositionInfo(organizationId);
            organizationUser.SetIsLeader(organizationId);
        }

        return pageOutput;
    }

    public async Task<PagedList<GetOrganizationUserPageOutput>> GetOrganizationUserPageAsync(long organizationId,
        GetOrganizationUserPageInput input)
    {
        var currentUserDataRange = await _session.GetCurrentUserDataRangeAsync();
        var userPage = await UserRepository
            .AsQueryable(false)
            .Include(p => p.UserSubsidiaries)
            .Where(!currentUserDataRange.IsAllData,
                p => p.UserSubsidiaries.Any(q =>
                    currentUserDataRange.OrganizationIds.Contains(q.OrganizationId) &&
                    q.OrganizationId == organizationId))
            .Where(p => p.UserSubsidiaries.Any(q => q.OrganizationId == organizationId))
            .OrderByDescending(p => p.CreatedTime)
            .ToPagedListAsync(input.PageIndex, input.PageSize);
        var userOutputList = userPage.Adapt<PagedList<GetOrganizationUserPageOutput>>();
        foreach (var userOutput in userOutputList.Items)
        {
            await userOutput.SetPositionInfo(organizationId);
            userOutput.IsLeader = userOutput.UserSubsidiaries.Single(p => p.OrganizationId == organizationId).IsLeader;
        }

        return userOutputList;
    }

    public async Task<ICollection<GetUserOutput>> GetOrganizationUsersAsync(long organizationId)
    {
        var users = UserRepository
            .AsQueryable(false)
            .Include(p => p.UserSubsidiaries)
            .Where(p => p.UserSubsidiaries.Any(us => us.OrganizationId == organizationId));
        return (await users.ToListAsync()).Adapt<ICollection<GetUserOutput>>();
    }

    public async Task<bool> HasOrganizationUsersAsync(long organizationId)
    {
        var userCount = await UserRepository
            .AsQueryable(false)
            .Include(p => p.UserSubsidiaries)
            .CountAsync(p => p.UserSubsidiaries.Any(us => us.OrganizationId == organizationId));
        return userCount > 0;
    }

    public async Task<bool> HasPositionUsersAsync(long positionId)
    {
        var userCount = await UserRepository
            .AsQueryable(false)
            .Include(p => p.UserSubsidiaries)
            .CountAsync(p => p.UserSubsidiaries.Any(us => us.PositionId == positionId));
        return userCount > 0;
    }

    public async Task UpdateClaimTypesAsync(long userId, ICollection<UpdateClaimTypeInput> inputs)
    {
        if (inputs.Any(i => i.UserId != userId))
        {
            throw new UserFriendlyException($"指定的userId不相等");
        }

        var currentUserClaims = await UserClaimRepository
            .AsQueryable(false)
            .Where(p => p.UserId == userId)
            .ToListAsync();

        var userClaims = new List<IdentityUserClaim>();
        foreach (var input in inputs)
        {
            var claimType = await ClaimTypeRepository.FirstOrDefaultAsync(p => p.Name == input.ClaimType);
            if (claimType == null)
            {
                throw new UserFriendlyException($"没有设置{input.ClaimType}的声明类型");
            }

            if (!claimType.Regex.IsNullOrEmpty() && !Regex.IsMatch(input.ClaimValue, claimType.Regex))
            {
                throw new UserFriendlyException($"设置的声明类型{input.ClaimType}的值{input.ClaimValue}格式不正确");
            }

            userClaims.Add(new IdentityUserClaim(input.UserId, input.ClaimType, input.ClaimValue));
        }

        await UserClaimRepository.DeleteAsync(currentUserClaims);
        await UserClaimRepository.InsertAsync(userClaims);
    }

    public async Task<IdentityResult> SetDefaultRolesAsync(IdentityUser user)
    {
        var defaultRoles = await ((IdentityUserStore)Store).DefaultRolesAsync();
        return await SetRolesAsync(user, defaultRoles.Select(p => p.Name));
    }

    public async Task<UserDataRange> GetUserDataRange(long userId)
    {
        UserDataRange userDataRange;
        var userRoles = await UserRepository.GetRolesAsync(userId).ToListAsync();
        if (userRoles.Any(p => p.DataRange == DataRange.Whole))
        {
            userDataRange = new UserDataRange(userId, true);
        }
        else
        {
            var userOrganizationIds = new List<long>();
            var roleDataRanges = new List<DataRange>();
            foreach (var role in userRoles)
            {
                if (roleDataRanges.Any(p => p == role.DataRange))
                {
                    continue;
                }

                switch (role.DataRange)
                {
                    case DataRange.CustomOrganization:
                        userOrganizationIds.AddRange(await GetRoleCustomDataRangeOrganizationIds(role.Id));
                        break;
                    case DataRange.SelfOrganization:
                        userOrganizationIds.AddRange(await GetSelfDataRangeOrganizationIds(userId));
                        break;
                    case DataRange.SelfAndChildrenOrganization:
                        userOrganizationIds.AddRange(await GetSelfAndChildrenDataRangeOrganizationIds(userId));
                        break;
                    default:
                        throw new BusinessException("role.DataRange is Wrong");
                }

                roleDataRanges.Add(role.DataRange);
            }

            userDataRange = new UserDataRange(userId, false, userOrganizationIds.Distinct().ToList());
        }

        return userDataRange;
    }

    private async Task<IEnumerable<long>> GetSelfAndChildrenDataRangeOrganizationIds(long userId)
    {
        var allSelfAndChildrenOrganizationIds = new List<long>();
        var user = await UserRepository
            .AsQueryable(false)
            .Include(p => p.UserSubsidiaries)
            .FirstAsync(p => p.Id == userId);
        foreach (var userSubsidiary in user.UserSubsidiaries)
        {
            var selfAndChildrenOrganizationIds =
                await _organizationAppService.GetSelfAndChildrenOrganizationIdsAsync(userSubsidiary.OrganizationId);
            allSelfAndChildrenOrganizationIds.AddRange(selfAndChildrenOrganizationIds);
        }

        return allSelfAndChildrenOrganizationIds;
    }

    private async Task<IEnumerable<long>> GetSelfDataRangeOrganizationIds(long userId)
    {
        var user = await UserRepository
            .AsQueryable(false)
            .Include(p => p.UserSubsidiaries).FirstAsync(p => p.Id == userId);
        return user.UserSubsidiaries.Select(p => p.OrganizationId);
    }


    private async Task<IEnumerable<long>> GetRoleCustomDataRangeOrganizationIds(long roleId)
    {
        var roleCustomDataRangeOrganizations =
            await RoleOrganizationRepository
                .AsQueryable(false)
                .Where(p => p.RoleId == roleId).ToListAsync();
        return roleCustomDataRangeOrganizations.Select(p => p.OrganizationId);
    }

    public virtual async Task<string> GetJobNumberAsync(IdentityUser user)
    {
        ThrowIfDisposed();
        if (user == null)
        {
            throw new ArgumentNullException(nameof(user));
        }

        return await ((IdentityUserStore)Store).GetJobNumberAsync(user, CancellationToken);
    }

    public Task<IdentityUser> FindByJobNumberAsync(string jobNumber)
    {
        return ((IdentityUserStore)Store).FindByJobNumberAsync(jobNumber);
    }

    public async Task<IdentityResult> SetJobNumberAsync(IdentityUser user, string jobNumber)
    {
        ThrowIfDisposed();
        await ((IdentityUserStore)Store).SetJobNumberAsync(user, jobNumber, CancellationToken);
        return await UpdateUserAsync(user);
    }

    public async Task<IdentityResult> CheckAllowUserMaxCount(IdentityUser user)
    {
        var userCount = await UserRepository.AsQueryable(false).CountAsync();
        var allowUserCountFeature = await _editionAppService.GetEditionFeatureAsync(FeatureCode.AllowMaxUserCount);
        if (allowUserCountFeature?.FeatureValue != 0 && userCount > allowUserCountFeature?.FeatureValue)
        {
            return IdentityResult.Failed(new IdentityError()
            {
                Code = "ExceededAllowMaxUserCount",
                Description = $"超过最允许的添加的最大用户量({allowUserCountFeature.FeatureValue})",
            });
        }

        return IdentityResult.Success;
    }

    public async Task<ICollection<GetRoleOutput>> GetUserRoleListAsync(long userId, string realName, string name)
    {
        var user = await UserRepository
            .AsQueryable(false)
            .Include(p => p.UserSubsidiaries)
            .FirstOrDefaultAsync(p => p.Id == userId);
        if (user == null)
        {
            throw new UserFriendlyException($"不存在Id为{userId}的账号");
        }

        var userOrganizationRoleIds = Array.Empty<long>();

        if (user.UserSubsidiaries.Any())
        {
            userOrganizationRoleIds = await _organizationAppService.GetOrganizationRoleIdsAsync(
                user.UserSubsidiaries.Select(p => p.OrganizationId).ToArray());
        }

        return await RoleRepository
            .AsQueryable(false)
            .Where(!realName.IsNullOrEmpty(), p => p.RealName.Contains(realName))
            .Where(!name.IsNullOrEmpty(), p => p.Name.Contains(name))
            .Where(p => (p.IsPublic || userOrganizationRoleIds.Contains(p.Id)) && p.Status == Status.Valid)
            .ProjectToType<GetRoleOutput>()
            .ToArrayAsync();
    }
}