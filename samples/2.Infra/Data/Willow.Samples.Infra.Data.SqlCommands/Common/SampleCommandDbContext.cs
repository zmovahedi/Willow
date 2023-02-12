using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Willow.Infra.Data.Sql.Commands;

namespace Willow.Samples.Infra.Data.SqlCommands.Common
{
    public class SampleCommandDbContext : BaseCommandDbContext
    {
        public SampleCommandDbContext(DbContextOptions<SampleCommandDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
