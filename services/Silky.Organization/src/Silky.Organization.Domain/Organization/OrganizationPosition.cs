using Silky.EntityFrameworkCore.Extras.Entities;

namespace Silky.Organization.Domain;

public class OrganizationPosition : AuditedEntity
{
    public long OrganizationId { get; set; }

    public long PositionId { get; set; }

    public Organization Organization { get; set; }
}