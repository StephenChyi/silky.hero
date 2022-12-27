using Silky.EntityFrameworkCore.Entities;
using Silky.EntityFrameworkCore.Extras.Entities;

namespace Silky.WorkFlow.Domain
{
    public class WorkFlowLog : Entity<long>, IHasCreatedTime
    {
        /// <summary>
        /// 单据主键
        /// </summary>
        public long ProofId { get; set; }

        /// <summary>
        /// 业务代码
        /// </summary>
        public string BusinessCategoryCode { get; set; }

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
