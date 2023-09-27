namespace Domain.Common.Bases;

public interface IBaseWriteRepository<T,TId> where T : BaseEntity<TId>
{
	  Task<T> AddAsync(T entity);
		Task<T> UpdateAsync(T entity);
		Task DeleteAsync(T entity);
		void AddEntity(T entity);
		void UpdateEntity(T entity);
		void DeleteEntity(T entity);
		void DeleteWhere(Expression<Func<T, bool>> where);
}