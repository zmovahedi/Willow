using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Willow.Core.Domain.Toolkits.ValueObjects;

namespace Willow.Infra.Data.Sql.Commands.ValueConversions
{
    public class TitleConversion : ValueConverter<Title, string>
    {
        public TitleConversion() : base(c => c.Value, c => Title.FromString(c))
        {

        }
    }
}
