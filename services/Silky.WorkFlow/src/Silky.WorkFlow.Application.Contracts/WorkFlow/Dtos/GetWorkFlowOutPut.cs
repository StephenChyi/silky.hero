using Silky.WorkFlow.Domain.Shared;

namespace Silky.WorkFlow.Application.Contracts.WorkFlow.Dtos
{
    public class GetWorkFlowOutput
    {
        public long Id { get; set; }

        /// <summary>
        /// 单据主键
        /// </summary>
        public long ProofId { get; set; }

        /// <summary>
        /// 业务代码
        /// </summary>
        public string BusinessCategoryCode { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string WorkFlowName { get; set; }

        /// <summary>
        /// 上一节点
        /// </summary>
        public long PreviousId { get; set; }

        /// <summary>
        /// 当前节点
        /// </summary>
        public long CurrentId { get; set; }

        /// <summary>
        /// 下一节点
        /// </summary>
        public long NextId { get; set; }

        /// <summary>
        /// 当前处理人
        /// </summary>
        public long CurrentUserId { get; set; }
        /// <summary>
        /// 当前处理人
        /// </summary>
        public string CurrentUserName { get; set; }

        /// <summary>
        /// 工作流节点
        /// </summary>
        public WorkFlowNodeOutput[] WorkFlowNodes { get; set; }

        /// <summary>
        /// 工作流节点连线
        /// </summary>
        public WorkFlowLineOutput[] WorkFlowLines { get; set; }

        /// <summary>
        /// 工作流记录
        /// </summary>
        public WorkFlowLogOutput[] WorkFlowLogs { get; set; }
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
    }

    /// <summary>
    /// 工作流节点连线
    /// </summary>
    public class WorkFlowLineOutput
    {
        public long Id { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string WorkFlowLineName { get; set; }

        /// <summary>
        /// 上一节点
        /// </summary>
        public long PrevWorkFlowNodeId { get; set; }

        /// <summary>
        /// 动作类型
        /// </summary>
        public ActionType ActionType { get; set; }

        /// <summary>
        /// 下一节点
        /// </summary>
        public long WorkFlowNodeId { get; set; }
    }
}
