namespace Silky.WorkFlow.Domain.Shared
{
    public enum NodeFactor
    {
        /// <summary>
        /// 小于 <
        /// </summary>
        Less,
        /// <summary>
        /// 不小于 >=(大于或等于)
        /// </summary>
        Notless,
        /// <summary>
        /// 大于 >
        /// </summary>
        Greater,
        /// <summary>
        /// 不大于 <=(小于或等于)
        /// </summary>
        Notgreater,
        /// <summary>
        /// 等于 ==
        /// </summary>
        Equal,
        /// <summary>
        /// 不等于 !=
        /// </summary>
        Notequal
    }
}
