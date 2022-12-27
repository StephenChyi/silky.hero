using Silky.EntityFrameworkCore.Entities;
using Silky.EntityFrameworkCore.Extras.Entities;

namespace Silky.WorkFlow.Domain
{
    public class WorkFlowLog : Entity<long>, IHasCreatedTime
    {
        /// <summary>
        /// 节点Id
        /// </summary>
        public long WorkFlowNodeId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long UserId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Memo { get; set; }

        public long WorkFlowId { get; set; }
        public virtual WorkFlow WorkFlow { get; set; }
    }
}
