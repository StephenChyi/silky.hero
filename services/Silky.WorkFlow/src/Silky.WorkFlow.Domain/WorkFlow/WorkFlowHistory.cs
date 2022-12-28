using Silky.EntityFrameworkCore.Entities;

namespace Silky.WorkFlow.Domain
{
    public class WorkFlowHistory : Entity<long>
    {
        public string WorkFlowNodeCode { get; set; }
        public string NextWorkFlowNodeCode { get; set; }
        public long WorkFlowId { get; set; }
        public virtual WorkFlow WorkFlow { get; set; }
    }
}
