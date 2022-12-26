using Silky.EntityFrameworkCore.Entities;
using Silky.WorkFlow.Domain.Shared;

namespace Silky.WorkFlow.Domain
{
    public class WorkFlowNodeCalculation : Entity<long>
    {
        public long WorkFlowNodeId { get; set; }

        public virtual WorkFlowNode WorkFlowNode { get; set; }

        /// <summary>
        /// 节点问题
        /// </summary>
        public string NodeVariable { get; set; }

        /// <summary>
        /// 节点条件
        /// </summary>
        public NodeFactor NodeFactor { get; set; }

        /// <summary>
        /// 节点答案
        /// </summary>
        public string NodeValue { get; set; }

        /// <summary>
        /// 节点串联
        /// </summary>
        public string NodeInseries { get; set; }

        /// <summary>
        /// 步骤编号
        /// </summary>
        public int NodeStepNo { get; set; }
    }
}
