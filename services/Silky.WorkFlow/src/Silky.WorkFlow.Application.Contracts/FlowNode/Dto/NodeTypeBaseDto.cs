using System.ComponentModel.DataAnnotations;

namespace Silky.WorkFlow.Application.Contracts.FlowNode.Dto
{
    public class NodeTypeBaseDto
    {
        /// <summary>
        /// 
        /// </summary>
        [Required(ErrorMessage = "节点类型代码不允许为空")]
        public string NodeTypeCode { get; set; }

        /// <summary>
        ///  
        /// </summary>
        [Required(ErrorMessage = "节点类型名称不允许为空")]
        public string NodeTypeName { get; set; }
    }
}
