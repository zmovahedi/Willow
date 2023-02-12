using FluentValidation;
using Willow.Extensions.Translations.Abstractions;
using Willow.Samples.Core.Contracts.People.Commands;
using Willow.Samples.Core.Domain;

namespace Willow.Samples.Core.ApplicationService.People.Commands.CreatePersonHandlers
{
    public class CreatePersonValidator : AbstractValidator<CreatePerson>
    {
        public CreatePersonValidator(ITranslator translator)
        {
            RuleFor(c => c.FirstName).NotEmpty().WithMessage(translator[Messages.InvalidNullValue, Messages.FirstName]);
            RuleFor(c => c.LastName).NotEmpty().WithMessage(translator[Messages.InvalidNullValue, Messages.LastName]);
        }
    }
}
