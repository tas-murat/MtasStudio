using MtasStudio.Domain.SeedWork;

namespace MtasStudio.Domain.AggregateModels
{
    public class OperationClaim : BaseEntity, IAggregateRoot
    {
        public string Name { get; set; }
    }
}
