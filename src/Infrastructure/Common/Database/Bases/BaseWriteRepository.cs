namespace Infrastructure.Common.Database.Bases;

public class BaseWriteRepository<T,TId> : IBaseWriteRepository<T,TId> where T: BaseEntity<TId>
{
	protected readonly CRMDbContext _context;

	public BaseWriteRepository(CRMDbContext context)
	{
			_context = context;
	}
	public async Task<T> AddAsync(T entity)
	{
			_context.Set<T>().Add(entity);
			await _context.SaveChangesAsync();
			return entity;
	}

	public async Task<T> UpdateAsync(T entity)
	{
			_context.Set<T>().Attach(entity);
			_context.Entry(entity).State = EntityState.Modified;
			await _context.SaveChangesAsync();

			return entity;
	}

	public async Task DeleteAsync(T entity)
	{
			_context.Set<T>().Remove(entity);
			await _context.SaveChangesAsync();
	}

	public void AddEntity(T entity)
	{
			_context.Set<T>().Add(entity);
	}

	public void UpdateEntity(T entity)
	{
			_context.Set<T>().Attach(entity);
			_context.Entry(entity).State = EntityState.Modified;
	}

	public void DeleteEntity(T entity)
	{
			_context.Set<T>().Remove(entity);
	}

	public void DeleteWhere(Expression<Func<T, bool>> where)
	{
			var entitiesToDelete = _context.Set<T>().Where(where);
			_context.Set<T>().RemoveRange(entitiesToDelete);
	}
}