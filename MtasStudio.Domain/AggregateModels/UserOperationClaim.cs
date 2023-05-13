using MtasStudio.Domain.SeedWork;

namespace MtasStudio.Domain.AggregateModels
{
    public class UserOperationClaim : BaseEntity, IAggregateRoot
    {
        public int UserId { get; set; }
        public int OperationClaimId { get; set; }
    }
}
