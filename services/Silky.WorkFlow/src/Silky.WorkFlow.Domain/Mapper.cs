using Mapster;
using Silky.WorkFlow.Application.Contracts.FlowNode.Dto;
using Silky.WorkFlow.Application.Contracts.WorkFlow.Dtos;

namespace Silky.WorkFlow.Domain
{
    public class Mapper : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config
               .ForType<NodeInPut, FlowNode>();
            config
               .ForType<FlowNode, FlowNodeOutPut>()
               .Map(dest => dest.NodeTypeName, src => src.NodeType.NodeTypeName);

            config
               .ForType<WorkFlowNode, WorkFlowNodeOutput>()
               .Map(dest => dest.NodeTypeName, src => src.NodeType.NodeTypeName);
        }
    }
}
