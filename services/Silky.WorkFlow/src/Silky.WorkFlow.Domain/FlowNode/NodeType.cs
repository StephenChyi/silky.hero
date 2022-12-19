using Silky.EntityFrameworkCore.Entities;

namespace Silky.WorkFlow.Domain
{
    public class NodeType : Entity<long>
    {
        /// <summary>
        /// 节点类型代码
        /// </summary>
        public string NodeTypeCode { get; set; }

        /// <summary>
        /// 节点类型名称
        /// </summary>
        public string NodeTypeName { get; set; }


        public virtual ICollection<FlowNode> FlowNodes { get; protected set; }

        public virtual ICollection<WorkFlowNode> WorkFlows { get; protected set; }
    }
}
