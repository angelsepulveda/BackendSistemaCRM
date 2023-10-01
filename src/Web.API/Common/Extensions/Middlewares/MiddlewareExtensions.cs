namespace Web.API.Common.Extensions.Middlewares;

public static class MiddlewareExtensions
{
  public static IApplicationBuilder AddMiddleware(this IApplicationBuilder builder)
  {
    builder.UseMiddleware<ValidationMiddleware>();
    builder.UseMiddleware<DomainExceptionMiddleware>();

    return builder;
  }
}

