namespace Silky.Identity.Application.Contracts.User.Dtos;

public class UpdateUserInput : UserDtoBase
{
    /// <summary>
    /// 用户id
    /// </summary>
    public long Id { get; set; }
}