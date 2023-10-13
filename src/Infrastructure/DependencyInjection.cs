using Domain.Common.Services;
using Domain.Usuarios.Colaboradores.Services;
using Infrastructure.Common.Database.UnitOfWork;
using Infrastructure.Common.Services;
using Infrastructure.Usuarios.Colaboradores.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services.AddDatabaseServices(configuration);
        services.AddServicesInfrastructure();

        return services;
    }

    private static IServiceCollection AddDatabaseServices(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        var connectionMysqlString = configuration.GetConnectionString("MySqlConnection");

        services.AddSingleton<IConfiguration>(configuration);

        services.AddDbContext<CRMDbContext>(
            options =>
                options.UseMySql(
                    connectionMysqlString,
                    ServerVersion.AutoDetect(connectionMysqlString)
                )
        );

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped(typeof(IBaseReadRepository<,>), typeof(BaseReadRepository<,>));
        services.AddScoped(typeof(IBaseWriteRepository<,>), typeof(BaseWriteRepository<,>));

        return services;
    }

    private static IServiceCollection AddServicesInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IHashPassword, HashPassword>();

        return services;
    }
}
