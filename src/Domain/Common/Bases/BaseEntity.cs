using System.Dynamic;

namespace Domain.Common.Bases;

public abstract class BaseEntity<TId>
{
	public TId Id { get; set; }
	public DateTime? CreatedAt { get; set; }
	public int? CreatedBy { get; set; }
	public DateTime? UpdatedAt { get; set; }
	public int? UpdatedBy { get; set; }
}