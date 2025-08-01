namespace Util;

// public static class DataBaseExtension
// {
//     public static WebApplication ApplyMigrations<TDbContext>(this WebApplication app)
//         where TDbContext : DbContext
//     {
//         using var scope = app.Services.CreateScope();
//         var services = scope.ServiceProvider;
        
//         try
//         {
//             var db = services.GetRequiredService<TDbContext>();
//             db.Database.Migrate();
//         }
//         catch (Exception ex)
//         {
//             var logger = services.GetRequiredService<ILogger<Program>>();
//             logger.LogError(ex, "An error occurred while migrating the database");
//             throw;
//         }

//         return app;
//     }
// }