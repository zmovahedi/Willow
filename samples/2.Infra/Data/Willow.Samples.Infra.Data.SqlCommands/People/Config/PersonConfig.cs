using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Willow.Samples.Core.Domain.People.Entities;
using Willow.Samples.Core.Domain.People.ValueObjects;

namespace Willow.Samples.Infra.Data.SqlCommands.People.Config
{
    public class PersonConfig : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.Property(x => x.FirstName).HasConversion(c => c.Value, c => new FirstName(c));
            builder.Property(x => x.LastName).HasConversion(c => c.Value, c => new LastName(c));
        }
    }
}
