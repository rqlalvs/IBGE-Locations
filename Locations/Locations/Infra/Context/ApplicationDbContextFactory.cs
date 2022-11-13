using Locations.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Locations.Infra.Context
{

    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseMySql("server=locations.cpdb1zmgllha.us-east-1.rds.amazonaws.com:3306;initial catalog=DB_LOCALIDADES;uid=admin;pwd=FPqRA1TrltfFLPafC97X",
        Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.28-mysql"));

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }

}
