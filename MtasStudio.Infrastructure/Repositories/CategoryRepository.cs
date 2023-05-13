using MtasStudio.Application.Interfaces.Repositories;
using MtasStudio.Domain.AggregateModels;
using MtasStudio.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MtasStudio.Infrastructure.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(MtasDbContext dbContext) : base(dbContext) { }
    }
}
