using Silky.EntityFrameworkCore.Entities;
using Silky.WorkFlow.Domain.Shared;

namespace Silky.WorkFlow.Domain
{
    public class NodeActionResult : Entity<long>
    {
        /// <summary>
        /// 上一节点
        /// </summary>
        public long PrevFlowNodeId { get; set; }

        /// <summary>
        /// 节点动作
        /// </summary>
        public NodeAction NodeAction { get; set; }

        /// <summary>
        /// 业务代码
        /// </summary>
        public string BusinessCategoryCode { get; set; }

        /// <summary>
        /// 节点ID
        /// </summary>
        public long FlowNodeId { get; set; }
        /// <summary>
        /// 节点对象
        /// </summary>
        public virtual FlowNode FlowNode { get; set; }
    }
}
