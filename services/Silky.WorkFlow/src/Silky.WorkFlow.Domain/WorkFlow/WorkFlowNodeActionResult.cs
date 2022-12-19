using Silky.EntityFrameworkCore.Entities;
using Silky.WorkFlow.Domain.Shared;

namespace Silky.WorkFlow.Domain
{
    public class WorkFlowNodeActionResult : Entity<long>
    {
        /// <summary>
        /// 
        /// </summary>
        public long WorkFlowId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public WorkFlowNode WorkFlow { get; set; }

        /// <summary>
        /// 代码
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
