using FluentValidation;
using Hackney.Core.Validation;
using Hackney.Shared.CautionaryAlerts.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hackney.Shared.CautionaryAlerts.Boundary.Request.Validation
{
    public class EndCautionaryAlertValidator : AbstractValidator<EndCautionaryAlert>
    {
        public EndCautionaryAlertValidator()
        {
            RuleFor(x => x.IncidentDescription)
                .NotEmpty().NotNull()
                .NotXssString()
                .When(x => !string.IsNullOrEmpty(x.IncidentDescription))
                .Must(x => x.Length <= CautionaryAlertConstants.INCIDENTDESCRIPTIONLENGTH);

            RuleFor(x => x.IncidentDate).NotEmpty().NotNull()
                .Must(date => date < DateTime.UtcNow)
                .NotEqual(DateTime.MinValue);

            RuleFor(x => x.AssureReference)
                .NotEmpty().NotNull()
                .NotXssString()
                .Must(x => x.Length <= CautionaryAlertConstants.ASSUREREFERENCELENGTH);

            RuleFor(x => x.Alert).SetValidator(new AlertValidator());

            RuleFor(x => x.AssetDetails).SetValidator(new AssetDetailsValidator());

            RuleFor(x => x.PersonDetails).SetValidator(new PersonDetailsValidator());

            RuleFor(x => x.AlertId).NotEmpty().NotNull();

            RuleFor(x => x.IsActive).Must(x => x.Equals(false));
        }
    }
}
