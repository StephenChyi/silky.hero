using Silky.Hero.Common.Enums;

namespace Silky.WorkFlow.Application.Contracts.WorkFlow.Dtos
{
    /// <summary>
    /// 业务工作流
    /// </summary>
    public class FlowNodeInPut
    {
        /// <summary>
        /// 业务代码
        /// </summary>
        public string BusinessCode { get; set; }

        /// <summary>
        /// 业务工作流节点集合
        /// </summary>
        public NodeInPut[] Nodes { get; set; }
    }

    /// <summary>
    /// 业务工作流节点
    /// </summary>
    public class NodeInPut
    {
        /// <summary>
        /// 代码
        /// </summary>
        public string NodeCode { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string NodeName { get; set; }

        /// <summary>
        /// 节点类型
        /// </summary>
        public long NodeTypeId { get; set; }

        /// <summary>
        /// 节点问题
        /// </summary>
        public string NodeVariable { get; set; }

        /// <summary>
        /// 节点答案
        /// </summary>
        public string NodeValue { get; set; }

        /// <summary>
        /// 节点动作
        /// </summary>
        public NodeAction NodeAction { get; set; }

        /// <summary>
        /// 下一节点
        /// </summary>
        public NodeActionResult[] NextNodes { get; set; }
    }

    public class NodeActionResult
    {
        /// <summary>
        /// 节点动作
        /// </summary>
        public NodeAction NodeAction { get; set; }

        /// <summary>
        /// 动作节点
        /// </summary>
        public NodeInPut NextNode { get; set; }
    }
}
