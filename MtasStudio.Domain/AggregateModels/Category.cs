using MtasStudio.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace MtasStudio.Domain.AggregateModels
{
    public class Category : BaseEntity, IAggregateRoot
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Slug { get; set; }
        public int? ParentId { get; set; }
        public bool IsPublished { get; set; } = false;
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public DateTime LastModifiedOn { get; set; }
        public DateTime PublishedOn { get; set; }
        public Category Parent { get; set; }
        public ICollection<Category> Children { get; set; }
        public ICollection<PostCategory> PostCategories { get; set; }

    }
}
