using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MtasStudio.Application.Models
{
    public class Sorting<T>
    {
        public string PropertyName { get; set; }
        public bool IsAscending { get; set; }

        public Sorting(string propertyName, bool isAscending)
        {
            PropertyName = propertyName;
            IsAscending = isAscending;
        }

        public IQueryable<T> Sort(IQueryable<T> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (string.IsNullOrEmpty(PropertyName))
            {
                return source;
            }

            var param = Expression.Parameter(typeof(T), "x");
            var property = Expression.Property(param, PropertyName);
            var lambda = Expression.Lambda(property, param);

            var methodName = IsAscending ? "OrderBy" : "OrderByDescending";

            var resultExpression = Expression.Call(typeof(Queryable), methodName, new[] { typeof(T), property.Type }, source.Expression, lambda);

            return source.Provider.CreateQuery<T>(resultExpression);
        }
    }
}
