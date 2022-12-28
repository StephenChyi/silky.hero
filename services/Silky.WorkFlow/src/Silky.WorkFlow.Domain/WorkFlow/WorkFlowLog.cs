using Silky.EntityFrameworkCore.Entities;
using Silky.WorkFlow.Domain.Shared;

namespace Silky.WorkFlow.Domain
{
    public class WorkFlowLog : Entity<long>
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
        public string WorkFlowNodeCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long UserId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 动作类型
        /// </summary>
        public ActionType ActionType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Memo { get; set; }

        public long WorkFlowId { get; set; }
        public virtual WorkFlow WorkFlow { get; set; }
    }
}
