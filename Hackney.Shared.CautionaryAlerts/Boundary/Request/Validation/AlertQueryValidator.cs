using FluentValidation;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Hackney.Shared.CautionaryAlerts.Boundary.Request.Validation
{
    public class AlertQueryValidator : AbstractValidator<AlertQueryObject>
    {
        public AlertQueryValidator()
        {
            RuleFor(x => x.AlertId).NotNull().NotEmpty();
        }
    }
}
