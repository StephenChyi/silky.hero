using Silky.Permission.Domain.Shared.Permission;
using System.Collections.Generic;

namespace Silky.Permission.Application.Contracts.Permission.Dtos;

public class AuthorizeInput
{
    public string ServiceEntryId { get; set; }

    public ICollection<AuthorizeData> AuthorizeDatas { get; set; }

}