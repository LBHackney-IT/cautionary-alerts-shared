using Hackney.Shared.CautionaryAlerts.Infrastructure;
using FluentValidation;

namespace Hackney.Shared.CautionaryAlerts.Boundary.Request.Validation
{
    public class AlertValidator : AbstractValidator<Alert>
    {
        public AlertValidator()
        {
            RuleFor(x => x.Code).NotNull().NotEmpty()
                .Must(x => x.Length <= CreateCautionaryAlertConstants.ALERTCODELENGTH);
            RuleFor(x => x.Code).NotNull().NotEmpty()
                .Must(x => x.Length <= CreateCautionaryAlertConstants.ALERTDESCRIPTION);
        }
    }
}
