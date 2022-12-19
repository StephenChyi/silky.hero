using Silky.EntityFrameworkCore.Entities;

namespace Silky.WorkFlow.Domain
{
    /// <summary>
    /// 业务流程节点
    /// </summary>
    public class FlowNode : Entity<long>
    {
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
        /// 下一节点
        /// </summary>
        public virtual ICollection<NodeActionResult> NextNodes { get; protected set; }
    }
}