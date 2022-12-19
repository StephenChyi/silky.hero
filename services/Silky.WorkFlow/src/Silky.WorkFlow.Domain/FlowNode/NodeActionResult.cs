using Silky.EntityFrameworkCore.Entities;
using Silky.WorkFlow.Domain.Shared;

namespace Silky.WorkFlow.Domain
{
    public class NodeActionResult : Entity<long>
    {
        /// <summary>
        /// 节点ID
        /// </summary>
        public long FlowNodeId { get; set; }

        /// <summary>
        /// 节点对象
        /// </summary>
        public FlowNode FlowNode { get; set; }

        /// <summary>
        /// 节点代码
        /// </summary>
        public string FlowNodeCode { get; set; }

        /// <summary>
        /// 节点动作
        /// </summary>
        public NodeAction NodeAction { get; set; }

        /// <summary>
        /// 下一节点
        /// </summary>
        public string NextFlowNodeId { get; set; }

        /// <summary>
        /// 下一节点代码
        /// </summary>
        public string NextFlowNodeCode { get; set; }
    }
}
