using Mapster;
using Microsoft.EntityFrameworkCore;
using Silky.Core.DbContext.UnitOfWork;
using Silky.EntityFrameworkCore.Repositories;
using Silky.WorkFlow.Application.Contracts.WorkFlow.Dtos;
using Silky.WorkFlow.Domain.Shared;

namespace Silky.WorkFlow.Domain
{
    public class FlowNodeDomainService : IFlowNodeDomainService
    {
        public IRepository<FlowNode> FlowNodeRepository { get; }

        public FlowNodeDomainService(IRepository<FlowNode> flowNodeRepository)
        {
            FlowNodeRepository = flowNodeRepository;
        }

        [UnitOfWork]
        public async Task CreateAsync(FlowNode[] flowNodes)
        {
            await FlowNodeRepository.InsertAsync(flowNodes);
        }

        public async Task<ICollection<FlowNode>> GetFlowNodesAsync(string businessCategoryCode)
        {
            return await FlowNodeRepository
                 .AsQueryable(false)
                 .AsNoTracking()
                 .Include(f => f.NodeType)
                 .Include(f => f.NextNodes)
                 .Where(f => f.BusinessCategoryCode == businessCategoryCode)
                 .OrderBy(f => f.StepNo)
                 .ToListAsync();
        }
    }
}
