using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreAssignment.DataAccess.Contexts
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<BaseDbContext>
    {
        public BaseDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<BaseDbContext> dbContextOptionsBuilder = new();
            dbContextOptionsBuilder.UseNpgsql("User ID=postgres;Password=123456;Host=localhost;Port=5432;Database=NetCoreAssignmentDb;");
            return new(dbContextOptionsBuilder.Options);
        }
    }
}
