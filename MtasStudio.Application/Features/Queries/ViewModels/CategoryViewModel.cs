using MtasStudio.Domain.AggregateModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MtasStudio.Application.Features.Queries.ViewModels
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Slug { get; set; }
        public int? ParentId { get; set; }
        public bool IsPublished { get; set; } = false;
        public ICollection<CategoryViewModel> Children { get; set; }
    }
}
