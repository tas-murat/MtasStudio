using MtasStudio.Domain.SeedWork;

namespace MtasStudio.Domain.AggregateModels
{
    public class Post : BaseEntity, IAggregateRoot
    {
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Summary { get; set; }
        public string PostContents { get; set; }
        public bool IsPublished { get; set; } = false;
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public DateTime LastModifiedOn { get; set; }
        public DateTime PublishedOn { get; set; }
        public List<PostTag> PostTags { get; set; }
        public List<PostCategory> PostCategories { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
