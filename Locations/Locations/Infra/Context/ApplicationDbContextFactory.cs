using Locations.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Locations.Infra.Context
{

    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var dbconn = System.Environment.GetEnvironmentVariable("DB_CONN_LOCATIONS-WPORT", EnvironmentVariableTarget.Machine);

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseMySql(dbconn,
        Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.28-mysql"), sqloptions => sqloptions.EnableRetryOnFailure());

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }

}
