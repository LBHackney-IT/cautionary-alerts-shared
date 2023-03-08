using AutoFixture;
using FluentValidation.TestHelper;
using Hackney.Shared.CautionaryAlerts.Boundary.Request;
using Hackney.Shared.CautionaryAlerts.Boundary.Request.Validation;
using Hackney.Shared.CautionaryAlerts.Infrastructure;
using NUnit.Framework;
using System;

namespace Hackney.Shared.CautionaryAlerts.Tests.Boundary.Validation
{
    [TestFixture]
    public class EndCautionaryAlertValidatorTests
    {
        private readonly EndCautionaryAlertValidator _classUnderTest;
        private readonly Fixture _fixture = new Fixture();

        public EndCautionaryAlertValidatorTests()
        {
            _classUnderTest = new EndCautionaryAlertValidator();
        }

        public const int INVALIDLENGTH = 2;


        public static (Alert alert, AssetDetails AssetDetails, PersonDetails personDetails) GenerateValidFixture(string defaultString, Fixture fixture, string addressString)
        {
            var alert = fixture.Build<Alert>()
                .With(x => x.Code, defaultString[..CautionaryAlertConstants.ALERTCODELENGTH])
                .With(x => x.Description, defaultString[..CautionaryAlertConstants.ALERTDESCRIPTION])
                .Create();

            var assetDetails = fixture.Build<AssetDetails>()
                .With(x => x.FullAddress, addressString[..CautionaryAlertConstants.FULLADDRESSLENGTH])
                .With(x => x.PropertyReference, defaultString[..CautionaryAlertConstants.PROPERTYREFERENCELENGTH])
                .With(x => x.UPRN, defaultString[..CautionaryAlertConstants.UPRNLENGTH])
                .Create();

            var personDetails = fixture.Build<PersonDetails>()
                .With(x => x.Name, defaultString[..CautionaryAlertConstants.PERSONNAMELENGTH])
                .Create();

            return (alert, assetDetails, personDetails);
        }

        [Test]
        public void AlertIdShouldFailIfNull()
        {
            var defaultString = string.Join("", _fixture.CreateMany<char>(CautionaryAlertConstants.INCIDENTDESCRIPTIONLENGTH));
            var addressString = string.Join("", _fixture.CreateMany<char>(CautionaryAlertConstants.FULLADDRESSLENGTH));
            var model = GenerateValidFixture(defaultString, _fixture, addressString);

            var cautionaryAlert = _fixture.Build<EndCautionaryAlert>()
                                        .With(x => x.Alert, model.alert)
                                        .With(x => x.PersonDetails, model.personDetails)
                                        .With(x => x.AssetDetails, model.AssetDetails)
                                        .With(x => x.IncidentDescription, defaultString[..CautionaryAlertConstants.INCIDENTDESCRIPTIONLENGTH])
                                        .With(x => x.IncidentDate, _fixture.Create<DateTime>().AddDays(-1))
                                        .With(x => x.AssureReference, defaultString[..CautionaryAlertConstants.ASSUREREFERENCELENGTH])
                                        .Without(x => x.AlertId)
                                        .Create();

            var result = _classUnderTest.TestValidate(cautionaryAlert);
            result.ShouldHaveValidationErrorFor(x => x.AlertId);

        }

        [Test]
        public void AlertIdShouldFailIfEmpty()
        {
            var defaultString = string.Join("", _fixture.CreateMany<char>(CautionaryAlertConstants.INCIDENTDESCRIPTIONLENGTH));
            var addressString = string.Join("", _fixture.CreateMany<char>(CautionaryAlertConstants.FULLADDRESSLENGTH));
            var model = GenerateValidFixture(defaultString, _fixture, addressString);

            var cautionaryAlert = _fixture.Build<EndCautionaryAlert>()
                                        .With(x => x.Alert, model.alert)
                                        .With(x => x.PersonDetails, model.personDetails)
                                        .With(x => x.AssetDetails, model.AssetDetails)
                                        .With(x => x.IncidentDescription, defaultString[..CautionaryAlertConstants.INCIDENTDESCRIPTIONLENGTH])
                                        .With(x => x.IncidentDate, _fixture.Create<DateTime>().AddDays(-1))
                                        .With(x => x.AssureReference, defaultString[..CautionaryAlertConstants.ASSUREREFERENCELENGTH])
                                        .With(x => x.AlertId, Guid.Empty)
                                        .Create();

            var result = _classUnderTest.TestValidate(cautionaryAlert);
            result.ShouldHaveValidationErrorFor(x => x.AlertId);


        }

        [Test]
        public void AlertIdShouldNotFailIfValid()
        {
            var defaultString = string.Join("", _fixture.CreateMany<char>(CautionaryAlertConstants.INCIDENTDESCRIPTIONLENGTH));
            var addressString = string.Join("", _fixture.CreateMany<char>(CautionaryAlertConstants.FULLADDRESSLENGTH));
            var model = GenerateValidFixture(defaultString, _fixture, addressString);

            var cautionaryAlert = _fixture.Build<EndCautionaryAlert>()
                                        .With(x => x.Alert, model.alert)
                                        .With(x => x.PersonDetails, model.personDetails)
                                        .With(x => x.AssetDetails, model.AssetDetails)
                                        .With(x => x.IncidentDescription, defaultString[..CautionaryAlertConstants.INCIDENTDESCRIPTIONLENGTH])
                                        .With(x => x.IncidentDate, _fixture.Create<DateTime>().AddDays(-1))
                                        .With(x => x.AssureReference, defaultString[..CautionaryAlertConstants.ASSUREREFERENCELENGTH])
                                        .With(x => x.AlertId, Guid.NewGuid())
                                        .Create();

            var result = _classUnderTest.TestValidate(cautionaryAlert);
            result.ShouldNotHaveValidationErrorFor(x => x.AlertId);


        }

        [Test]
        public void IsActiveShouldFailIfTrue()
        {
            var defaultString = string.Join("", _fixture.CreateMany<char>(CautionaryAlertConstants.INCIDENTDESCRIPTIONLENGTH));
            var addressString = string.Join("", _fixture.CreateMany<char>(CautionaryAlertConstants.FULLADDRESSLENGTH));
            var model = GenerateValidFixture(defaultString, _fixture, addressString);

            var cautionaryAlert = _fixture.Build<EndCautionaryAlert>()
                                        .With(x => x.Alert, model.alert)
                                        .With(x => x.PersonDetails, model.personDetails)
                                        .With(x => x.AssetDetails, model.AssetDetails)
                                        .With(x => x.IncidentDescription, defaultString[..CautionaryAlertConstants.INCIDENTDESCRIPTIONLENGTH])
                                        .With(x => x.IncidentDate, _fixture.Create<DateTime>().AddDays(-1))
                                        .With(x => x.AssureReference, defaultString[..CautionaryAlertConstants.ASSUREREFERENCELENGTH])
                                        .With(x => x.AlertId, Guid.NewGuid())
                                        .With(x => x.IsActive, true)
                                        .Create();

            var result = _classUnderTest.TestValidate(cautionaryAlert);
            result.ShouldHaveValidationErrorFor(x => x.IsActive);


        }

        [Test]
        public void IsActiveShouldNotFailIfFalse()
        {
            var defaultString = string.Join("", _fixture.CreateMany<char>(CautionaryAlertConstants.INCIDENTDESCRIPTIONLENGTH));
            var addressString = string.Join("", _fixture.CreateMany<char>(CautionaryAlertConstants.FULLADDRESSLENGTH));
            var model = GenerateValidFixture(defaultString, _fixture, addressString);

            var cautionaryAlert = _fixture.Build<EndCautionaryAlert>()
                                        .With(x => x.Alert, model.alert)
                                        .With(x => x.PersonDetails, model.personDetails)
                                        .With(x => x.AssetDetails, model.AssetDetails)
                                        .With(x => x.IncidentDescription, defaultString[..CautionaryAlertConstants.INCIDENTDESCRIPTIONLENGTH])
                                        .With(x => x.IncidentDate, _fixture.Create<DateTime>().AddDays(-1))
                                        .With(x => x.AssureReference, defaultString[..CautionaryAlertConstants.ASSUREREFERENCELENGTH])
                                        .With(x => x.AlertId, Guid.NewGuid())
                                        .With(x => x.IsActive, false)
                                        .Create();

            var result = _classUnderTest.TestValidate(cautionaryAlert);
            result.ShouldNotHaveValidationErrorFor(x => x.IsActive);

        }
    }
}
