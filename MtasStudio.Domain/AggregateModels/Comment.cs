using MtasStudio.Domain.SeedWork;

namespace MtasStudio.Domain.AggregateModels
{
    public class Comment : BaseEntity, IAggregateRoot
    {
        public string CommentContents { get; set; }
        public string PostedBy { get; set; }
        public int? ParentId { get; set; }
        public bool IsPublished { get; set; } = false;
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public DateTime LastModifiedOn { get; set; }
        public DateTime PublishedOn { get; set; }
        public int ParentPostId { get; set; }
        public Comment Parent { get; set; }
        public ICollection<Comment> Children { get; set; }
        public Post ParentPost { get; set; }

    }
}
