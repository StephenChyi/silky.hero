using Silky.EntityFrameworkCore.Entities;
using Silky.WorkFlow.Domain.Shared;

namespace Silky.WorkFlow.Domain
{
    public class FlowLine : Entity<long>
    {
        /// <summary>
        /// 业务代码
        /// </summary>
        public string BusinessCategoryCode { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string FlowLineName { get; set; }

        /// <summary>
        /// 动作类型
        /// </summary>
        public ActionType ActionType { get; set; }

        /// <summary>
        /// 上一节点
        /// </summary>
        public string PrevFlowNodeCode { get; set; }

        /// <summary>
        /// 下一节点
        /// </summary>
        public string FlowNodeCode { get; set; }

        /// <summary>
        /// 所属流
        /// </summary>
        public long FlowId { get; set; }

        public virtual Flow Flow { get; set; }
    }
}
