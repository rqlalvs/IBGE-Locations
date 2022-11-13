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
            optionsBuilder.UseSqlServer("server=locations.cpdb1zmgllha.us-east-1.rds.amazonaws.com:3306;initial catalog=DB_LOCALIDADES;uid=admin;pwd=FPqRA1TrltfFLPafC97X");

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }

}
