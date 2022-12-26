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
        /// 单据主键
        /// </summary>
        public long ProofId { get; set; }

        /// <summary>
        /// 业务代码
        /// </summary>
        public string BusinessCategoryCode { get; set; }

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
        public long NodeTypeId { get; set; }

        /// <summary>
        /// 节点类型
        /// </summary>
        public virtual NodeType NodeType { get; protected set; }

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

        /// <summary>
        /// 上一个节点ID
        /// </summary>
        public long PreviousId { get; set; }

        /// <summary>
        /// 下一节点
        /// </summary>
        public virtual ICollection<WorkFlowNodeActionResult> NextFlowNodes { get; set; }
    }
}