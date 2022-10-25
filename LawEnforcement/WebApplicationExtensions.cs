using LawEnforcementDB.Context;
using Microsoft.EntityFrameworkCore;

namespace LawEnforcement;
public static class WebApplicationExtensions
{
    public static void ApplyPendingMigrations(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var services = scope.ServiceProvider;

        var context = services.GetRequiredService<LawEnforcementContext>();
        if (context.Database.GetPendingMigrations().Any())
            context.Database.Migrate();
    }
}
