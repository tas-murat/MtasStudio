using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MtasStudio.Domain.AggregateModels;
using Polly;
using Polly.Retry;

namespace MtasStudio.Infrastructure.Context
{
    public class MtasDbContextSeed
    {
        public async Task SeedAsync(MtasDbContext context, ILogger<MtasDbContext> logger)
        {
            var policy = CreatePolicy(logger, nameof(MtasDbContextSeed));
            await policy.ExecuteAsync(async () =>
            {
                using (context)
                {
                    context.Database.Migrate();
                    if (!context.Categories.Any())
                    {
                        context.Categories.AddRange(GetDefaultCategories());
                        await context.SaveChangesAsync();
                    }
                    if (!context.Tags.Any())
                    {
                        context.Tags.AddRange( GetDefaultTags());
                        await context.SaveChangesAsync();
                    }
                }
            });
        }

        private IEnumerable<Tag> GetDefaultTags()
        {
          return new List<Tag>
          {
              new Tag {Title="Tag1",Description="Default oluşturulan bir tag 1",Slug="tag1"},
              new Tag {Title="Tag2",Description="Default oluşturulan bir tag 2",Slug="tag2"},
              new Tag {Title="Tag3",Description="Default oluşturulan bir tag 3",Slug="tag3"},
              new Tag {Title="Tag4",Description="Default oluşturulan bir tag 4",Slug="tag4"},
          };
        }

        private IEnumerable<Category> GetDefaultCategories()
        {
            return new List<Category>
            {
                new Category{Title="Category 1",Slug="category1",Description="Default oluşturulan bir Category 1"},
                new Category{Title="Category 2",Slug="category2",Description="Default oluşturulan bir Category 2"},
                new Category{Title="Category 3",Slug="category3",Description="Default oluşturulan bir Category 3"},
                new Category{Title="Category 4",Slug="category4",Description="Default oluşturulan bir Category 4"},
            };
        }

        private AsyncRetryPolicy CreatePolicy(ILogger<MtasDbContext> logger, string prefix, int retries = 3)
        {
            return Policy.Handle<SqlException>().
                WaitAndRetryAsync(
                retryCount: retries,
                sleepDurationProvider: retry => TimeSpan.FromSeconds(5),
                 onRetry: (exception, timespan, retry, ctx) =>
                 {
                     logger.LogWarning(exception,
                         "[{prefix} Exception {ExceptionType} with message {message} detected on attempt {retry} ]", "SqlConn", typeof(SqlException).Name, exception.Message, retry);
                 });

        }
    }
}
