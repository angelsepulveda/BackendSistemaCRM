namespace Application.Common.Exceptions;

public class ValidationCustomException : Exception
{
   public IEnumerable<BaseError>? Errors { get; }

	 public ValidationCustomException() : base()
	 {
		 Errors = new List<BaseError>();
	 }

	 public ValidationCustomException(IEnumerable<BaseError>? errors): this()
	 {
		 Errors = errors;
	 }
}