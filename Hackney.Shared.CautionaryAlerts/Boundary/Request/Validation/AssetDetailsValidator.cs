using Hackney.Shared.CautionaryAlerts.Infrastructure;
using FluentValidation;
using Hackney.Core.Validation;
using System;

namespace Hackney.Shared.CautionaryAlerts.Boundary.Request.Validation
{
    public class AssetDetailsValidator : AbstractValidator<AssetDetails>
    {
        public AssetDetailsValidator()
        {
            RuleFor(x => x.FullAddress)
                .NotXssString()
                .Must(x => x.Length <= CautionaryAlertConstants.FULLADDRESSLENGTH);

            RuleFor(x => x.PropertyReference)
                .NotXssString()
                .Must(x => x.Length <= CautionaryAlertConstants.PROPERTYREFERENCELENGTH);

            RuleFor(x => x.UPRN)
                .NotXssString()
                .Must(x => x.Length <= CautionaryAlertConstants.UPRNLENGTH);
        }
    }
}
