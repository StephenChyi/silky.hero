using Silky.EntityFrameworkCore.Entities;
using Silky.WorkFlow.Domain.Shared;

namespace Silky.WorkFlow.Domain
{
    /// <summary>
    /// 具体到某一数据的工作流
    /// </summary>
    public class WorkFlowNode : Entity<long>
    {
        /// <summary>
        /// 代码
        /// </summary>
        public string FlowNodeCode { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string FlowNodeName { get; set; }

        /// <summary>
        /// 节点类型
        /// </summary>
        public NodeType NodeType { get; set; }

        /// <summary>
        /// 节点问题
        /// </summary>
        public string NodeVariable { get; set; }

        /// <summary>
        /// 节点答案
        /// </summary>
        public string NodeValue { get; set; }

        /// <summary>
        /// 步骤编号
        /// </summary>
        public int StepNo { get; set; }

        /// <summary>
        /// 节点状态
        /// </summary>
        public WorkFlowNodeStatus NodeStatus { get; set; }

        public long WorkFlowId { get; set; }
        public virtual WorkFlow WorkFlow { get; set; }
    }
}