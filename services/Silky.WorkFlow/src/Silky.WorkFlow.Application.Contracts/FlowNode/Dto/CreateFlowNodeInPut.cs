using Silky.WorkFlow.Domain.Shared;
using System.ComponentModel.DataAnnotations;

namespace Silky.WorkFlow.Application.Contracts.FlowNode.Dto
{
    /// <summary>
    /// 业务工作流
    /// </summary>
    public class CreateFlowNodeInPut
    {
        /// <summary>
        /// 业务代码
        /// </summary>
        [Required(ErrorMessage = "业务类型代码不允许为空")]
        public string BusinessCategoryCode { get; set; }

        /// <summary>
        /// 业务工作流节点集合
        /// </summary>
        public NodeInPut StartNode { get; set; }
    }

    /// <summary>
    /// 业务工作流节点
    /// </summary>
    public class NodeInPut
    {
        /// <summary>
        /// 代码
        /// </summary>
        [Required(ErrorMessage = "节点代码不允许为空")]
        public string FlowNodeCode { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [Required(ErrorMessage = "节点名称不允许为空")]
        public string FlowNodeName { get; set; }

        /// <summary>
        /// 节点类型
        /// </summary>
        [Required(ErrorMessage = "节点类型代码不允许为空")]
        public long NodeTypeId { get; set; }

        /// <summary>
        /// 节点问题
        /// </summary>
        [Required(ErrorMessage = "节点问题不允许为空")]
        public string NodeVariable { get; set; }

        /// <summary>
        /// 节点答案
        /// </summary>
        [Required(ErrorMessage = "节点答案不允许为空")]
        public string NodeValue { get; set; }

        /// <summary>
        /// 下一节点
        /// </summary>        
        public NodeActionResultOutput[] NextNodes { get; set; }
    }

    public class NodeActionResultOutput
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
