namespace Domain.Common.Bases;

public abstract class BaseEntity<TId>
{
		public TId Id { get; set; }
}