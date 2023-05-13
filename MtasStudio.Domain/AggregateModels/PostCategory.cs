using MtasStudio.Domain.SeedWork;

namespace MtasStudio.Domain.AggregateModels
{
    public class PostCategory : BaseEntity, IAggregateRoot
    {
        public int PostId { get; set; }
        public Post Post { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
