using Silky.EntityFrameworkCore.Entities;
using Silky.WorkFlow.Domain.Shared;

namespace Silky.WorkFlow.Domain
{
    /// <summary>
    /// 工作流连线
    /// </summary>
    public class WorkFlowLine : Entity<long>
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string WorkFlowLineName { get; set; }

        /// <summary>
        /// 上一节点
        /// </summary>
        public string PrevWorkFlowNodeCode { get; set; }

        /// <summary>
        /// 动作类型
        /// </summary>
        public ActionType ActionType { get; set; }

        /// <summary>
        /// 下一节点
        /// </summary>
        public string WorkFlowNodeCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long WorkFlowId { get; set; }
        public virtual WorkFlow WorkFlow { get; set; }
    }
}