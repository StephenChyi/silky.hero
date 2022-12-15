﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Silky.Permission.Application.Contracts.Menu.Dtos;
using Silky.Permission.Domain.Shared;
using Silky.Rpc.CachingInterceptor;
using Silky.Rpc.Routing;
using Silky.Rpc.Runtime.Server;
using Silky.Rpc.Security;

namespace Silky.Permission.Application.Contracts.Menu;

/// <summary>
/// 菜单服务
/// </summary>
[ServiceRoute]
[Authorize]
public interface IMenuAppService
{
    /// <summary>
    /// 新增菜单
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [Authorize(PermissionPermissions.Menus.Create)]
    Task CreateAsync(CreateMenuInput input);
    
    /// <summary>
    /// 检查菜单是否存在
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost("check")]
    Task<bool> CheckAsync(CheckMenuInput input);

    /// <summary>
    /// 更新菜单
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [RemoveCachingIntercept(typeof(GetMenuOutput), "id:{Id}")]
    [RemoveCachingIntercept(typeof(bool), "HasMenu:{Id}")]
    [Authorize(PermissionPermissions.Menus.Update)]
    Task UpdateAsync(UpdateMenuInput input);

    /// <summary>
    /// 通过Id获取菜单
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet]
    [GetCachingIntercept("id:{id}")]
    [Authorize(PermissionPermissions.Menus.LookDetail)]
    Task<GetMenuOutput> GetAsync(long id);

    /// <summary>
    /// 根据id删除菜单
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [RemoveCachingIntercept(typeof(GetMenuOutput), "id:{id}")]
    [RemoveCachingIntercept(typeof(bool), "HasMenu:{id}")]
    [Authorize(PermissionPermissions.Menus.Delete)]
    Task DeleteAsync(long id);

    
    /// <summary>
    /// 获取菜单树
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    Task<ICollection<GetMenuTreeOutput>> GetTreeAsync([FromQuery]string name);

    /// <summary>
    /// 根据Id判断是否存在菜单
    /// </summary>
    /// <param name="menuId"></param>
    /// <returns></returns>
    [GetCachingIntercept("HasMenu:{menuId}")]
    [ProhibitExtranet]
    Task<bool> HasMenuAsync(long menuId);

    [ProhibitExtranet]
    Task<ICollection<string>> GetPermissions(List<long> menuIds);

    [ProhibitExtranet]
    Task<ICollection<GetMenuOutput>> GetMenusAsync(long[] menuIds,bool includeParents = true);

    [ProhibitExtranet]
    Task<long[]> GetAllMenuIdsAsync(bool onlyValid = true);
}