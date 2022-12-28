using Silky.WorkFlow.Domain.Shared;

namespace Silky.WorkFlow.Application.Contracts.WorkFlow.Dtos
{
    /// <summary>
    /// 工作流记录
    /// </summary>
    public class GetWorkFlowLogsOutput
    {
        public DateTimeOffset CreatedTime { get; set; }
        /// <summary>
        /// 动作类型
        /// </summary>
        public ActionType ActionType { get; set; }

        /// <summary>
        /// 操作人
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Memo { get; set; }
    }

    /// <summary>
    /// 工作流记录
    /// </summary>
    public class WorkFlowLogOutput
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
        /// 节点Id
        /// </summary>
        public long WorkFlowNodeId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long UserId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 动作类型
        /// </summary>
        public ActionType ActionType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Memo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTimeOffset CreatedTime { get; set; }
    }
}
