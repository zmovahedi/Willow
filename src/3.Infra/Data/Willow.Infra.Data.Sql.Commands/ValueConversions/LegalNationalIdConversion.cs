﻿using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Willow.Core.Domain.Toolkits.ValueObjects;

namespace Willow.Infra.Data.Sql.Commands.ValueConversions
{
    public class LegalNationalIdConversion : ValueConverter<LegalNationalId, string>
    {
        public LegalNationalIdConversion() : base(c => c.Value, c => LegalNationalId.FromString(c))
        {

        }
    }
}
