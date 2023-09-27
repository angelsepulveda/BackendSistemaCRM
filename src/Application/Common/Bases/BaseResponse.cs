namespace Application.Common.Bases;

public class BaseReponse<T>
{
	public bool IsSuccess { get; set; }
	public T? Data { get; set; }
	public string Message { get; set; } = string.Empty;
	public IEnumerable<BaseError>? Errors { get; set; }
}