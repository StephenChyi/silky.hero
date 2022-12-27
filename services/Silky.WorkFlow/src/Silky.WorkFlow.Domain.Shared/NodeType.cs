namespace Silky.WorkFlow.Domain.Shared
{
    public enum NodeType
    {
        /// <summary>
        /// 开始
        /// </summary>
        Start,
        /// <summary>
        /// 结束
        /// </summary>
        End,
        /// <summary>
        /// 计算
        /// </summary>
        Calculate,
        /// <summary>
        /// 审核
        /// </summary>
        Audit
    }
}
