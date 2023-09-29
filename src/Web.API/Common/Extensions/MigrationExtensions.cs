using Infrastructure.Common.Database.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Web.API.Common.Extensions;

public static class MigrationExtensions
{
    public static void ApplyMigrations(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        var dbContext = scope.ServiceProvider.GetRequiredService<CRMDbContext>();

        dbContext.Database.Migrate();
    }
}
