using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace LabWarmers.DataAccess
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<WarmersDbContext>
    {
        public WarmersDbContext CreateDbContext(string[] args)
        {
            var options = new DbContextOptionsBuilder<WarmersDbContext>();
            options.UseSqlServer("Data Source=DESKTOP-NEKK0AN\\INSTANCE;Initial Catalog=LabWarmers;Integrated Security=True");

            return new(options.Options);
        }
    }
}
