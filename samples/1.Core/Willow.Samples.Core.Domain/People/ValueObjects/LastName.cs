using Willow.Core.Domain.ValueObjects;

namespace Willow.Samples.Core.Domain.People.ValueObjects
{
    public class LastName : ValueObject<LastName>
    {
        public string Value { get; private set; }

        public LastName(string value)
        {
            value = value.Trim();

            if (string.IsNullOrWhiteSpace(value))
                throw new InvalidValueObjectStateException(Messages.InvalidNullValue, Messages.LastName);

            if (value.Length < 2 || value.Length > 50)
                throw new InvalidValueObjectStateException(Messages.InvalidStringLength, Messages.LastName, "2", "50");

            Value = value;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
