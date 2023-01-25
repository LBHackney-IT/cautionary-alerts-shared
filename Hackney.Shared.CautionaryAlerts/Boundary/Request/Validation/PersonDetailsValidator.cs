using Hackney.Shared.CautionaryAlerts.Infrastructure;
using FluentValidation;
using Hackney.Core.Validation;
using System;

namespace Hackney.Shared.CautionaryAlerts.Boundary.Request.Validation
{
    public class PersonDetailsValidator : AbstractValidator<PersonDetails>
    {
        public PersonDetailsValidator()
        {
            RuleFor(x => x.Id).NotNull()
                .NotEqual(Guid.Empty);

            RuleFor(x => x.Name).NotNull()
                .NotEmpty()
                .NotXssString()
                .Must(x => x.Length <= CreateCautionaryAlertConstants.PERSONNAMELENGTH);
        }
    }
}
