using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Willow.Core.Domain.Toolkits.ValueObjects;

namespace Willow.Infra.Data.Sql.Commands.ValueConversions
{
    public class NationalCodeConversion : ValueConverter<NationalCode, string>
    {
        public NationalCodeConversion() : base(c => c.Value, c => NationalCode.FromString(c))
        {

        }
    }
}
