using Silky.Identity.Domain.Shared;
using System;
using System.Collections.Generic;

namespace Silky.Identity.Application.Contracts.Role.Dtos;

public class GetRoleDetailOutput : RoleDtoBase
{

    /// <summary>
    /// 主键Id
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// 角色所拥有的菜单权限
    /// </summary>
    public ICollection<GetRoleMenuTreeOutput> Menus { get; set; }

    /// <summary>
    /// 数据权限范围
    /// </summary>
    public DataRange DataRange { get; set; }

    /// <summary>
    /// 用户所有的数据权限范围
    /// </summary>
    public ICollection<GetCustomOrganizationOutput> CustomOrganizationDataRanges { get; set; }

    public DateTimeOffset CreatedTime { get; set; }

    public DateTimeOffset? UpdatedTime { get; set; }

}