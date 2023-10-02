using System.Net;
using Domain.Common.Exceptions;

namespace Web.API.Common.Extensions.Middlewares;

public class DomainExceptionMiddleware
{
  private readonly RequestDelegate _next;

  public DomainExceptionMiddleware(RequestDelegate next)
  {
    _next = next ?? throw new ArgumentNullException(nameof(next));
  }

  public async Task Invoke(HttpContext context)
  {
    try
    {
      await _next.Invoke(context);
    }
    catch (DomainException ex)
    {
      context.Response.ContentType = "application/json";
      context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

      await JsonSerializer.SerializeAsync(context.Response.Body, new BaseResponse<object>
      {
        IsSuccess = false,
        Message = ex.Message
      });
    }
  }
}