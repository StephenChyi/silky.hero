﻿using Mapster;

namespace Silky.WorkFlow.Domain
{
    public class Mapper : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            //config.ForType<WorkFlow, GetWorkFlowCurrentOutput>();                
            //config.ForType<WorkFlowNode, WorkFlowNodeOutput>();
            //config.ForType<WorkFlowLine, WorkFlowLineOutput>();
            //config.ForType<WorkFlowLog, WorkFlowLogOutput>();

        }
    }
}