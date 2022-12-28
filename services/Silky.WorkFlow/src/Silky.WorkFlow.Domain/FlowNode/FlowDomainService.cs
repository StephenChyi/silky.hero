﻿using Microsoft.EntityFrameworkCore;
using Silky.Core.DbContext.UnitOfWork;
using Silky.EntityFrameworkCore.Repositories;

namespace Silky.WorkFlow.Domain
{
    public class FlowDomainService : IFlowDomainService
    {
        public IRepository<Flow> FlowRepository { get; }
        public IRepository<FlowNode> FlowNodeRepository { get; }
        public IRepository<FlowLine> FlowLineResults { get; }
        public IRepository<NodeCalculation> NodeCalculations { get; }

        public FlowDomainService(IRepository<Flow> flowRepository, IRepository<FlowNode> flowNodeRepository, IRepository<FlowLine> flowLineResults, IRepository<NodeCalculation> nodeCalculations)
        {
            FlowRepository = flowRepository;
            FlowNodeRepository = flowNodeRepository;
            FlowLineResults = flowLineResults;
            NodeCalculations = nodeCalculations;
        }

        [UnitOfWork]
        public async Task CreateAsync(Flow flow)
        {
            await FlowRepository.InsertAsync(flow);
        }

        public async Task<Flow> GetAsync(string businessCategoryCode)
        {
            return await FlowRepository
                .Include(f => f.FlowNodes)
                .ThenInclude(f => f.NodeCalculations)
                .Include(f => f.FlowLines)
                .AsNoTracking()
                .FirstOrDefaultAsync(f => f.BusinessCategoryCode == businessCategoryCode);
        }
    }
}
