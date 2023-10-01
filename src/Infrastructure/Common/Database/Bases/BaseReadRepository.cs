using Infrastructure.Common.Database.Specifications;

namespace Infrastructure.Common.Database.Bases;

public class BaseReadRepository<T, TId> : IBaseReadRepository<T, TId> where T : BaseEntity<TId>
{
	protected readonly CRMDbContext _context;

	public BaseReadRepository(CRMDbContext context)
	{
		_context = context;
	}

	public async Task<IReadOnlyList<T>> GetAllAsync()
	{
		return await _context.Set<T>().ToListAsync();
	}

	public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate)
	{
		return await _context.Set<T>().Where(predicate).ToListAsync();
	}

	public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null,
			Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
			string includeString = null,
			bool disableTracking = true)
	{
		IQueryable<T> query = _context.Set<T>();
		if (disableTracking) query = query.AsNoTracking();

		if (!string.IsNullOrWhiteSpace(includeString)) query = query.Include(includeString);

		if (predicate != null) query = query.Where(predicate);

		if (orderBy != null)
			return await orderBy(query).ToListAsync();

		return await query.ToListAsync();
	}

	public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null,
			Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
			List<Expression<Func<T, object>>> includes = null,
			bool disableTracking = true)
	{
		IQueryable<T> query = _context.Set<T>();

		if (disableTracking) query = query.AsNoTracking();

		if (includes != null) query = includes.Aggregate(query, (current, include) => current.Include(include));

		if (predicate != null) query = query.Where(predicate);

		if (orderBy != null)
			return await orderBy(query).ToListAsync();

		return await query.ToListAsync();
	}

	public async Task<T?> GetByIdAsync(TId id)
	{
		return await _context.Set<T>().FindAsync(id);
	}

	public async Task<T?> GetByWithSpec(ISpecification<T> spec)
	{
		return await ApplySpecification(spec).FirstOrDefaultAsync();
	}

	public async Task<IReadOnlyList<T>> GetAllWithSpec(ISpecification<T> spec)
	{
		return await ApplySpecification(spec).ToListAsync();
	}

	public async Task<int> CountAsync(ISpecification<T> spec)
	{
		return await ApplySpecification(spec).CountAsync();
	}

	public IQueryable<T> ApplySpecification(ISpecification<T> spec)
	{
		return SpecificationEvaluator<T>.GetQuery(_context.Set<T>().AsQueryable(), spec);
	}
}