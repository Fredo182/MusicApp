using System;
using System.Linq;
using System.Linq.Expressions;

namespace MusicApp.Data.Helpers
{
    public interface IOrderByClause<T> where T : class
    {
        IOrderedQueryable<T> ApplySort(IQueryable<T> query, bool firstSort);
    }

    public class OrderByClause<T, TProperty> : IOrderByClause<T> where T : class, new()
    {
        public OrderByClause() { }

        public OrderByClause(Expression<Func<T, TProperty>> orderBy, string sortDirection = "asc")
        {
            OrderBy = orderBy;
            SortDirection = sortDirection;
        }


        private Expression<Func<T, TProperty>> OrderBy { get; set; }
        private string SortDirection { get; set; }


        public IOrderedQueryable<T> ApplySort(IQueryable<T> query, bool firstSort)
        {
            if (SortDirection == "desc")
            {
                if (firstSort)
                    return query.OrderByDescending(OrderBy);
                else
                    return ((IOrderedQueryable<T>)query).ThenByDescending(OrderBy);
            }
            else
            {
                if (firstSort)
                    return query.OrderBy(OrderBy);
                else
                    return ((IOrderedQueryable<T>)query).ThenBy(OrderBy);
            }
        }
    }
}
