using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Willow.Core.Domain.Toolkits.ValueObjects;

namespace Willow.Infra.Data.Sql.Commands.ValueConversions
{
    public class DescriptionConversion : ValueConverter<Description, string>
    {
        public DescriptionConversion() : base(c => c.Value, c => Description.FromString(c))
        {

        }
    }
}
