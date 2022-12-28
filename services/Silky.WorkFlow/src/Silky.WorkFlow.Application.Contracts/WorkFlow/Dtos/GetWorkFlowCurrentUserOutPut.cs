namespace Silky.WorkFlow.Application.Contracts.WorkFlow.Dtos
{
    public class GetWorkFlowCurrentOutPut
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
        /// 当前节点
        /// </summary>
        public WorkFlowNodeOutput CurrentWorkFlowNode { get; set; }

        /// <summary>
        /// 当前节点连线
        /// </summary>
        public WorkFlowLineOutput[] WorkFlowLines { get; set; }
    }
}
