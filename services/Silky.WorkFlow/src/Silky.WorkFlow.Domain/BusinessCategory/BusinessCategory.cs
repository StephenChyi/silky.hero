using Silky.EntityFrameworkCore.Entities;

namespace Silky.WorkFlow.Domain
{
    public class BusinessCategory : Entity<long>
    {
        public string BusinessName { get; set; }

        public string BusinessCode { get; set; }
    }
}
