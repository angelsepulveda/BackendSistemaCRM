namespace Web.API.Common.Extensions.Middlewares;
public class ValidationMiddleware
{
  private readonly RequestDelegate _next;

  public ValidationMiddleware(RequestDelegate next)
  {
    _next = next ?? throw new ArgumentNullException(nameof(next));
  }

  public async Task Invoke(HttpContext context)
  {
    try
    {
      await _next.Invoke(context);
    }
    catch (ValidationCustomException ex)
    {
      context.Response.ContentType = "application/json";
      await JsonSerializer.SerializeAsync(context.Response.Body, new BaseReponse<object>
      {
        Message = "Errores de Validación",
        Errors = ex.Errors
      });
    }
  }
}