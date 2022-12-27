using Silky.EntityFrameworkCore.Entities;

namespace Silky.WorkFlow.Domain
{
    /// <summary>
    /// 一个业务流
    /// </summary>
    public class Flow : Entity<long>
    {
        /// <summary>
        /// 业务代码
        /// </summary>
        public string BusinessCategoryCode { get; set; }

        /// <summary>
        /// 流名称
        /// </summary>
        public string FlowName { get; set; }

        /// <summary>
        /// 流节点
        /// </summary>
        public virtual ICollection<FlowNode> FlowNodes { get; protected set; }

        /// <summary>
        /// 流节点连线
        /// </summary>
        public virtual ICollection<FlowLine> FlowLines { get; protected set; }
    }
}
