using MtasStudio.Domain.SeedWork;

namespace MtasStudio.Domain.AggregateModels
{
    public class PostTag : BaseEntity, IAggregateRoot
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public Post Post { get; set; }
        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
