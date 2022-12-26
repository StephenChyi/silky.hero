using Silky.EntityFrameworkCore.Entities;
using Silky.WorkFlow.Domain.Shared;

namespace Silky.WorkFlow.Domain
{
    public class WorkFlowNodeActionResult : Entity<long>
    {
        /// <summary>
        /// 上一节点
        /// </summary>
        public long PrevWorkFlowNodeId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string BusinessCategoryCode { get; set; }

        /// <summary>
        /// 节点动作
        /// </summary>
        public NodeAction NodeAction { get; set; }

        /// <summary>
        /// 单据主键
        /// </summary>
        public long ProofId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long WorkFlowNodeId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual WorkFlowNode WorkFlowNode { get; set; }
    }
}
