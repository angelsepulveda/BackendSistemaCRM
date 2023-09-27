namespace Infrastructure.Common.Database.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
	 private Hashtable _repositories;
	 private readonly CRMDbContext _context;

		public UnitOfWork(CRMDbContext context)
		{
				_context = context;
		}

		public void Dispose()
		{
				_context.Dispose();
		}

		public IBaseWriteRepository<TEntity,TId> WriteRepository<TEntity,TId>() where TEntity : BaseEntity<TId>
		{
				if (_repositories == null)
				{
						_repositories = new Hashtable();
				}

				var type = typeof(TEntity).Name;

				if (!_repositories.ContainsKey(type))
				{
						var repositoryType = typeof(BaseWriteRepository<,>);
						var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity), typeof(TId)), _context);
						_repositories.Add(type, repositoryInstance);
				}

				return (IBaseWriteRepository<TEntity,TId>)_repositories[type];
		}

		public async Task<int> Complete()
		{
				return await _context.SaveChangesAsync();
		}
}