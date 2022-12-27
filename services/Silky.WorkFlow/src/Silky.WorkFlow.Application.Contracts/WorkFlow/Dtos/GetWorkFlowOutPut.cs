using Silky.WorkFlow.Domain.Shared;

namespace Silky.WorkFlow.Application.Contracts.WorkFlow.Dtos
{
    public class GetWorkFlowOutPut
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
        /// 开始节点
        /// </summary>
        public WorkFlowNodeOutput StartNode { get; set; }
    }

    /// <summary>
    /// 工作流节点
    /// </summary>
    public class WorkFlowNodeOutput
    {
        public long Id { get; set; }

        /// <summary>
        /// 代码
        /// </summary>
        public string FlowNodeCode { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string FlowNodeName { get; set; }

        /// <summary>
        ///  节点类型名称
        /// </summary>
        public string NodeTypeName { get; set; }

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
        public WorkFlowNodeActionResultOutput[] NextNodes { get; set; }
    }

    public class WorkFlowNodeActionResultOutput
    {
        public long Id { get; set; }
        /// <summary>
        /// 节点动作
        /// </summary>
        public NodeAction NodeAction { get; set; }

        /// <summary>
        /// 下一节点
        /// </summary>
        public WorkFlowNodeOutput WorkFlowNode { get; set; }
    }
}
