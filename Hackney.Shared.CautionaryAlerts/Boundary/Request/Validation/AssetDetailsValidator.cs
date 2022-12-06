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
                .Must(x => x.Length <= CreateCautionaryAlertConstants.FULLADDRESSLENGTH);

            RuleFor(x => x.PropertyReference)
                .NotXssString()
                .Must(x => x.Length <= CreateCautionaryAlertConstants.PROPERTYREFERENCELENGTH);

            RuleFor(x => x.UPRN)
                .NotXssString()
                .Must(x => x.Length <= CreateCautionaryAlertConstants.UPRNLENGTH);
        }
    }
}
