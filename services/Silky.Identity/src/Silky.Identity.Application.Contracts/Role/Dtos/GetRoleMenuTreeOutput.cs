using System.Collections.Generic;

namespace Silky.Identity.Application.Contracts.Role.Dtos;

public class GetRoleMenuTreeOutput
{
    public long MenuId { get; set; }
    
    public string Name { get; set; }
    
    public string Title { get; set; }
    
    public ICollection<GetRoleMenuTreeOutput> Children { get; set; }
    
}