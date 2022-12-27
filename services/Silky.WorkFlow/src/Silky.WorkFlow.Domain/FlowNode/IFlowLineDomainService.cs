using Silky.Core.DependencyInjection;
using Silky.EntityFrameworkCore.Repositories;

namespace Silky.WorkFlow.Domain
{
    public interface IFlowLineDomainService : IScopedDependency
    {
        IRepository<FlowLine> FlowLineRepository { get; }
    }
}
