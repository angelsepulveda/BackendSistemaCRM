using Domain.Common.Specifications;

namespace Domain.Common.Bases;

public interface IBaseReadRepository<T, TId> where T : BaseEntity<TId>
{
     Task<IReadOnlyList<T>> GetAllAsync();
     Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate);
     Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null,
     Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
     string includeString = null,
     bool disableTracking = true);
     Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null,
     Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
     List<Expression<Func<T, object>>> includes = null,
     bool disableTracking = true);

     Task<T?> GetByWithSpec(ISpecification<T> spec);

     Task<IReadOnlyList<T>> GetAllWithSpec(ISpecification<T> spec);

     Task<int> CountAsync(ISpecification<T> spec);
}