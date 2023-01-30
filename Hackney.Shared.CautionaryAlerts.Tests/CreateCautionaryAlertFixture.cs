using AutoFixture;
using Hackney.Shared.CautionaryAlerts.Boundary.Request;
using Hackney.Shared.CautionaryAlerts.Infrastructure;
using System;

namespace Hackney.Shared.CautionaryAlerts.Tests
{
    public static class CreateCautionaryAlertFixture
    {
        public static CreateCautionaryAlert GenerateValidCreateCautionaryAlertFixture(string defaultString, Fixture fixture, string addressString)
        {
            var alert = fixture.Build<Alert>()
                .With(x => x.Code, defaultString[..CreateCautionaryAlertConstants.ALERTCODELENGTH])
                .With(x => x.Description, defaultString[..CreateCautionaryAlertConstants.ALERTDESCRIPTION])
                .Create();

            var assetDetails = fixture.Build<AssetDetails>()
                .With(x => x.FullAddress, addressString[..CreateCautionaryAlertConstants.FULLADDRESSLENGTH])
                .With(x => x.PropertyReference, defaultString[..CreateCautionaryAlertConstants.PROPERTYREFERENCELENGTH])
                .With(x => x.UPRN, defaultString[..CreateCautionaryAlertConstants.UPRNLENGTH])
                .Create();

            var personDetails = fixture.Build<PersonDetails>()
                .With(x => x.Name, defaultString[..CreateCautionaryAlertConstants.PERSONNAMELENGTH])
                .Create();

            var cautionaryAlert = fixture.Build<CreateCautionaryAlert>()
                .With(x => x.Alert, alert)
                .With(x => x.PersonDetails, personDetails)
                .With(x => x.AssetDetails, assetDetails)
                .With(x => x.IncidentDescription, defaultString[..CreateCautionaryAlertConstants.INCIDENTDESCRIPTIONLENGTH])
                .With(x => x.IncidentDate, fixture.Create<DateTime>().AddDays(-1))
                .With(x => x.AssureReference, defaultString[..CreateCautionaryAlertConstants.ASSUREREFERENCELENGTH])
                .Create();

            return cautionaryAlert;
        }

        public static CreateCautionaryAlert GenerateValidCreateCautionaryAlertWithoutAssetDetailsFixture(string defaultString, Fixture fixture)
        {
            var alert = fixture.Build<Alert>()
                .With(x => x.Code, defaultString[..CreateCautionaryAlertConstants.ALERTCODELENGTH])
                .With(x => x.Description, defaultString[..CreateCautionaryAlertConstants.ALERTDESCRIPTION])
                .Create();


            var personDetails = fixture.Build<PersonDetails>()
                .With(x => x.Name, defaultString[..CreateCautionaryAlertConstants.PERSONNAMELENGTH])
                .Create();

            var cautionaryAlert = fixture.Build<CreateCautionaryAlert>()
                .With(x => x.Alert, alert)
                .With(x => x.PersonDetails, personDetails)
                .With(x => x.IncidentDescription, defaultString[..CreateCautionaryAlertConstants.INCIDENTDESCRIPTIONLENGTH])
                .With(x => x.IncidentDate, fixture.Create<DateTime>().AddDays(-1))
                .With(x => x.AssureReference, defaultString[..CreateCautionaryAlertConstants.ASSUREREFERENCELENGTH])
                .Without(x => x.AssetDetails)
                .Create();

            return cautionaryAlert;
        }
    }
}
