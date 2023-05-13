using MtasStudio.Application.Interfaces.Repositories;
using MtasStudio.Domain.AggregateModels;
using MtasStudio.Infrastructure.Context;

namespace MtasStudio.Infrastructure.Repositories
{
    public class TagRepository : GenericRepository<Tag>, ITagRepository
    {
        public TagRepository(MtasDbContext dbContext) : base(dbContext) { }
    }
}
