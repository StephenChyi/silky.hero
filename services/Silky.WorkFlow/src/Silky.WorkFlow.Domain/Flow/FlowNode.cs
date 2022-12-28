using Silky.EntityFrameworkCore.Entities;
using Silky.WorkFlow.Domain.Shared;

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
        public NodeType NodeType { get; set; }

        /// <summary>
        /// 节点计算集合
        /// </summary>
        public virtual ICollection<NodeCalculation> NodeCalculations { get; set; } = new List<NodeCalculation>();

        /// <summary>
        /// 所属流
        /// </summary>
        public long FlowId { get; set; }

        public virtual Flow Flow { get; set; }
    }
}