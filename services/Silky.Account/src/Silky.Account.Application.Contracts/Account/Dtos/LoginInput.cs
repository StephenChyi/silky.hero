using System.ComponentModel.DataAnnotations;
using Silky.Rpc.Auditing;

namespace Silky.Account.Application.Contracts.Account.Dtos;

/// <summary>
/// 登录参数
/// </summary>
public class LoginInput
{
    /// <summary>
    /// 账号
    /// </summary>
    [Required(ErrorMessage = "账号不允许为空")] public string Account { get; set; }

    /// <summary>
    /// 密码
    /// </summary>
    [Required(ErrorMessage = "密码不允许为空")]
    [DisableAuditing]
    public string Password { get; set; }

    /// <summary>
    /// 所属租户标识
    /// </summary>
    public string TenantName { get; set; }
}