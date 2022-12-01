using Hackney.Shared.CautionaryAlerts.Infrastructure;
using FluentValidation;
using Hackney.Core.Validation;
using System;

namespace Hackney.Shared.CautionaryAlerts.Boundary.Request.Validation
{
    public class CreateCautionaryAlertValidator : AbstractValidator<CreateCautionaryAlert>
    {
        public CreateCautionaryAlertValidator()
        {
            RuleFor(x => x.IncidentDescription)
                .NotEmpty().NotNull()
                .NotXssString()
                .When(x => !string.IsNullOrEmpty(x.IncidentDescription))
                .Must(x => x.Length <= CreateCautionaryAlertConstants.INCIDENTDESCRIPTIONLENGTH);

            RuleFor(x => x.IncidentDate).NotEmpty().NotNull()
                .Must(date => date < DateTime.UtcNow)
                .NotEqual(DateTime.MinValue);

            RuleFor(x => x.AssureReference)
                .NotEmpty().NotNull()
                .NotXssString()
                .Must(x => x.Length <= CreateCautionaryAlertConstants.ASSUREREFERENCELENGTH);

            RuleFor(x => x.Alert).SetValidator(new AlertValidator());

            RuleFor(x => x.AssetDetails).SetValidator(new AssetDetailsValidator());

            RuleFor(x => x.PersonDetails).SetValidator(new PersonDetailsValidator());
        }
    }
}
