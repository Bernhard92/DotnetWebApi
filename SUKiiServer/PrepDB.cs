using Microsoft.EntityFrameworkCore;
using SUKiiServer.Infrastructure.DataAccess;

namespace SUKiiServer
{
    public static class PrepDB
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            // Migrates on Server start-up remove this and replace it with a better migration strategy
            using var serviceScope = app.ApplicationServices.CreateScope();
            var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
            if (context == null)
            {
                throw new Exception("Context not found");
            }
            context.Database.Migrate();
            Console.WriteLine("Finished migrating");
        }
    }
}