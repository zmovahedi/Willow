using Willow.Core.Domain.ValueObjects;
using Willow.Utilities.Extensions;

namespace Willow.Samples.Core.Domain.People.ValueObjects
{
    public class FirstName : ValueObject<FirstName>
    {
        public string Value { get; private set; }

        public FirstName(string value)
        {
            value = value.Trim();

            if (string.IsNullOrWhiteSpace(value))
                throw new InvalidValueObjectStateException(Messages.InvalidNullValue, Messages.FirstName);

            if (value.IsLengthBetween(2, 50))
                throw new InvalidValueObjectStateException(Messages.InvalidStringLength, Messages.FirstName, "2", "50");

            Value = value;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
