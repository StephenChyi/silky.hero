using System.ComponentModel.DataAnnotations;

namespace Silky.WorkFlow.Application.Contracts.FlowNode.Dto
{
    public class UpdateNodeTypeInput
    {
        [Required(ErrorMessage = "Id不允许为空")]
        public long Id { get; set; }
    }
}
