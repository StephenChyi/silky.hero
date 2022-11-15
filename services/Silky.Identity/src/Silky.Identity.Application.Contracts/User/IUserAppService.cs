﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Silky.Identity.Application.Contracts.Role.Dtos;
using Silky.Identity.Application.Contracts.User.Dtos;
using Silky.Identity.Domain.Shared;
using Silky.Organization.Domain.Shared;
using Silky.Rpc.CachingInterceptor;
using Silky.Rpc.Routing;
using Silky.Rpc.Runtime.Server;
using Silky.Rpc.Security;
using Silky.Transaction;

namespace Silky.Identity.Application.Contracts.User;

/// <summary>
/// 用户信息服务
/// </summary>
[ServiceRoute]
[Authorize]
public interface IUserAppService
{
    /// <summary>
    /// 新增用户
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [Authorize(IdentityPermissions.Users.Create)]
    Task CreateAsync(CreateUserInput input);

    /// <summary>
    /// 判断是否存在某个账号
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost("check")]
    Task<bool> CheckAsync(CheckAccountInput input);

    /// <summary>
    /// 更新用户
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [RemoveCachingIntercept(typeof(GetUserOutput), "id:{id}")]
    [RemoveCachingIntercept(typeof(GetUserRoleOutput), "roles:userId:{id}")]
    [RemoveCachingIntercept(typeof(ICollection<long>), "roleIds:userId:{id}")]
    [Authorize(IdentityPermissions.Users.Update)]
    Task UpdateAsync(UpdateUserInput input);

    /// <summary>
    /// 删除用户
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id:long}")]
    [RemoveCachingIntercept(typeof(GetUserOutput), "id:{id}")]
    [RemoveCachingIntercept(typeof(GetUserRoleOutput), "roles:userId:{id}")]
    [RemoveCachingIntercept(typeof(ICollection<long>), "roleIds:userId:{id}")]
    [Authorize(IdentityPermissions.Users.Delete)]
    Task DeleteAsync(long id);

    /// <summary>
    /// 根据id获取用户信息
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id:long}")]
    [GetCachingIntercept("id:{id}")]
    [Authorize(IdentityPermissions.Users.LookDetail)]
    Task<GetUserOutput> GetAsync(long id);

    /// <summary>
    /// 分页查询用户信息
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    Task<PagedList<GetUserPageOutput>> GetPageAsync(GetUserPageInput input);

    /// <summary>
    /// 获取指定组织机构可增加的用户
    /// </summary>
    /// <param name="organizationId"></param>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet("{organizationId:long}/organizationuser/page")]
    [Authorize(OrganizationPermissions.Organizations.AddUsers)]
    Task<PagedList<GetAddOrganizationUserPageOutput>> GetAddOrganizationUserPageAsync(long organizationId,
        GetAddOrganizationUserPageInput input);

    [ProhibitExtranet]
    Task<PagedList<GetOrganizationUserPageOutput>> GetOrganizationUserPageAsync(long organizationId,
        GetOrganizationUserPageInput input);

    /// <summary>
    /// 更新用户声明
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="inputs"></param>
    /// <returns></returns>
    [HttpPut("{userId:long}/claims")]
    [Authorize(IdentityPermissions.Users.UpdateClaimTypes)]
    Task UpdateClaimTypesAsync(long userId, ICollection<UpdateClaimTypeInput> inputs);

    /// <summary>
    /// 授权用户角色
    /// </summary>
    /// <param name="userId">用户Id</param>
    /// <param name="roleNames">角色名称</param>
    /// <returns></returns>
    [HttpPut("{userId:long}/roles")]
    [Authorize(IdentityPermissions.Users.SetRoles)]
    [RemoveCachingIntercept(typeof(GetUserOutput), "id:{userId}")]
    [RemoveCachingIntercept(typeof(GetUserRoleOutput), "roles:userId:{userId}")]
    [RemoveCachingIntercept(typeof(ICollection<long>), "roleIds:userId:{userId}")]
    Task SetRolesAsync(long userId, ICollection<string> roleNames);

    /// <summary>
    /// 通过用户Id获取角色名称
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    [HttpGet("{userId:long}/roles")]
    [Authorize(IdentityPermissions.Users.SetRoles)]
    [GetCachingIntercept("roles:userId:{userId}")]
    Task<GetUserRoleOutput> GetRolesAsync(long userId);

    /// <summary>
    /// 根据id锁定用户账号
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="lockoutSeconds"></param>
    /// <returns></returns>
    [HttpPut("{userId:long}/lock/{lockoutSeconds:int}")]
    [Authorize(IdentityPermissions.Users.Lock)]
    [RemoveCachingIntercept(typeof(GetUserOutput), "id:{userId}")]
    Task LockAsync(long userId, int lockoutSeconds);

    /// <summary>
    /// 根据Id解锁用户账号
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    [HttpPut("{userId:long}/unlock")]
    [Authorize(IdentityPermissions.Users.UnLock)]
    [RemoveCachingIntercept(typeof(GetUserOutput), "id:{userId}")]
    Task UnLockAsync(long userId);

    /// <summary>
    /// 修改用户密码
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPut("{userId:long}/password")]
    [Authorize(IdentityPermissions.Users.ChangePassword)]
    Task ChangePasswordAsync(long userId, ChangePasswordInput input);

    /// <summary>
    /// 获取该用户可用于分配的角色列表
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="realName"></param>
    /// <param name="name"></param>
    /// <returns></returns>
    [HttpGet("{userId:long}/role/list")]
    [Authorize(IdentityPermissions.Users.SetRoles)]
    Task<ICollection<GetRoleOutput>> GetUserRoleListAsync(long userId, [FromQuery] string realName,
        [FromQuery] string name);

    /// <summary>
    /// 获取指定组织机构的用户
    /// </summary>
    /// <param name="organizationId">组织机构id</param>
    /// <returns></returns>
    [ProhibitExtranet]
    Task<ICollection<GetUserOutput>> GetOrganizationUsersAsync(long organizationId);

    /// <summary>
    /// 判断是否组织机构存在用户
    /// </summary>
    /// <param name="organizationId">组织机构id</param>
    /// <returns></returns>
    [ProhibitExtranet]
    Task<bool> HasOrganizationUsersAsync(long organizationId);

    /// <summary>
    /// 判断某个职位是否存在用户
    /// </summary>
    /// <param name="positionId">岗位id</param>
    /// <returns></returns>
    [ProhibitExtranet]
    Task<bool> HasPositionUsersAsync(long positionId);

    /// <summary>
    /// 通过用户Id获取角色Ids
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    [ProhibitExtranet]
    [GetCachingIntercept("roleIds:userId:{userId}")]
    Task<ICollection<long>> GetRoleIdsAsync(long userId);

    [ProhibitExtranet]
    Task<ICollection<long>> GetUserIdsAsync(long organizationId);

    [ProhibitExtranet]
    Task AddOrganizationUsers(long organizationId, ICollection<AddOrganizationUserInput> inputs);

    [ProhibitExtranet]
    Task RemoveOrganizationUsers(long organizationId, long[] userIds);

    [ProhibitExtranet]
    [Transaction]
    Task RemoveOrganizationLinkedDataAsync(long[] organizationIds);

    [ProhibitExtranet]
    [Transaction]
    Task CreateSuperUserAsync(CreateSuperUserInput superUserInput);

    [ProhibitExtranet]
    Task<bool> CheckHasLeaderAsync(long organizationId, long? userId);
}