namespace Domain.Common.UnitOfWork;

public interface IUnitOfWork : IDisposable
{
	IBaseWriteRepository<TEntity, TId> WriteRepository<TEntity, TId>() where TEntity : BaseEntity<TId>;
	Task<int> Complete();
}