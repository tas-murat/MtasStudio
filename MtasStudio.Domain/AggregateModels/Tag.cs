using MtasStudio.Domain.SeedWork;

namespace MtasStudio.Domain.AggregateModels
{
    public class Tag : BaseEntity, IAggregateRoot
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Slug { get; set; }
        public bool IsPublished { get; set; } = false;
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public DateTime LastModifiedOn { get; set; }
        public DateTime PublishedOn { get; set; }
        public ICollection<PostTag> PostTags { get; set; }
    }
}
