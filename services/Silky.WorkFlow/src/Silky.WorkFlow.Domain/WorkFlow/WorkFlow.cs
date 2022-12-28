using Silky.EntityFrameworkCore.Entities;

namespace Silky.WorkFlow.Domain
{
    /// <summary>
    /// 单据工作流
    /// </summary>
    public class WorkFlow : Entity<long>
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
        /// 名称
        /// </summary>
        public string WorkFlowName { get; set; }

        /// <summary>
        /// 上一节点
        /// </summary>
        public string PreviousNodeCode { get; set; }

        /// <summary>
        /// 当前节点代码
        /// </summary>
        public string CurrentNodeCode { get; set; }

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
        public virtual ICollection<WorkFlowNode> WorkFlowNodes { get; set; }

        /// <summary>
        /// 工作流节点连线
        /// </summary>
        public virtual ICollection<WorkFlowLine> WorkFlowLines { get; set; }

        /// <summary>
        /// 工作流记录
        /// </summary>
        public virtual ICollection<WorkFlowHistory> WorkFlowHistories { get; set; }

        /// <summary>
        /// 工作流操作日志
        /// </summary>
        public virtual ICollection<WorkFlowLog> WorkFlowLogs { get; set; }
    }
}
