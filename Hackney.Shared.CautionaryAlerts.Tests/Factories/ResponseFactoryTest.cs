using System;
using AutoFixture;
using Hackney.Shared.CautionaryAlerts.Domain;
using Hackney.Shared.CautionaryAlerts.Factories;
using FluentAssertions;
using NUnit.Framework;
using Hackney.Shared.CautionaryAlerts.Infrastructure.GoogleSheets;

namespace Hackney.Shared.CautionaryAlerts.Tests.Factories
{
    public class ResponseFactoryTest
    {
        [Test]
        public void CanMapACautionaryAlertDomainToResponse()
        {
            var fixture = new Fixture();
            var domain = fixture.Create<CautionaryAlert>();
            var response = domain.ToResponse();

            response.Description.Should().Be(domain.Description);
            response.AlertCode.Should().Be(domain.AlertCode);
            response.ModifiedBy.Should().Be(domain.ModifiedBy);
            response.DateModified.Should().Be(DateTimeToDateString(domain.DateModified.Value));
            response.EndDate.Should().Be(DateTimeToDateString(domain.EndDate.Value));
            response.StartDate.Should().Be(DateTimeToDateString(domain.StartDate.Value));
            response.IsActive.Should().Be(domain.IsActive);
            response.AlertId.Should().Be(domain.AlertId);
        }

        [Test]
        public void CanMapACautionaryAlertPersonToAResponse()
        {
            var fixture = new Fixture();
            var domain = fixture.Create<CautionaryAlertPerson>();
            var response = domain.ToResponse();

            response.Alerts.Should().BeEquivalentTo(domain.Alerts.ToResponse());
            response.ContactNumber.Should().Be(domain.ContactNumber);
            response.PersonNumber.Should().Be(domain.PersonNumber);
            response.TenancyAgreementReference.Should().Be(domain.TagRef);
        }

        private static string DateTimeToDateString(DateTime date)
        {
            return $"{date.Year}-{date.Month:00}-{date.Day:00}";
        }

        [Test]
        public void CanMapAPropertyCautionaryAlertToAResponse()
        {
            var fixture = new Fixture();
            var domain = fixture.Create<CautionaryAlertsProperty>();
            var response = domain.ToResponse();

            response.Alerts.Should().BeEquivalentTo(domain.Alerts.ToResponse());
            response.AddressNumber.Should().Be(domain.AddressNumber);
            response.PropertyReference.Should().Be(domain.PropertyReference);
            response.UPRN.Should().Be(domain.UPRN);
        }

        [Test]
        public void CanSendThroughNullPersonId()
        {
            var fixture = new Fixture();
            var domain = fixture.Build<CautionaryAlertListItem>()
                                .Without(x => x.PersonId)
                                .Create();
            var response = domain.ToResponse();
            response.PersonId.Should().BeNull();

        }

        [Test]
        public void CanParseGuidPersonId()
        {
            var fixture = new Fixture();
            var personId = Guid.NewGuid();
            var domain = fixture.Build<CautionaryAlertListItem>()
                                .With(x => x.PersonId, personId.ToString())
                                .Create();
            var response = domain.ToResponse();
            response.PersonId.Should().Be(personId);

        }

        [Test]
        public void PersonIdNullIfEmptyGuid()
        {
            var fixture = new Fixture();
            var personId = Guid.Empty;
            var domain = fixture.Build<CautionaryAlertListItem>()
                                .With(x => x.PersonId, personId.ToString())
                                .Create();
            var response = domain.ToResponse();
            response.PersonId.Should().BeNull();

        }

        [Test]
        public void PersonIdNullIfRandomString()
        {
            var fixture = new Fixture();
            var personId = "test";
            var domain = fixture.Build<CautionaryAlertListItem>()
                                .With(x => x.PersonId, personId)
                                .Create();
            var response = domain.ToResponse();
            response.PersonId.Should().BeNull();

        }

        [Test]
        public void CanMapAPropertyAlertDomainObjectToACautionaryListItemResponse()
        {
            // Arrange
            var fixture = new Fixture();
            var propertyAlertDomain = fixture.Create<PropertyAlertDomain>();

            // Act
            var response = propertyAlertDomain.ToResponse();
            
            // Assert
            response.AlertId.Should().Be(propertyAlertDomain.AlertId);
            response.IsActive.Should().Be(propertyAlertDomain.IsActive);
            response.DoorNumber.Should().Be(propertyAlertDomain.DoorNumber);
            response.Address.Should().Be(propertyAlertDomain.Address);
            response.AssureReference.Should().Be(propertyAlertDomain.AssureReference);
            response.Code.Should().Be(propertyAlertDomain.Code);
            response.DateOfIncident.Should().Be(propertyAlertDomain.DateOfIncident);
            response.CautionOnSystem.Should().Be(propertyAlertDomain.CautionOnSystem);
            response.Name.Should().Be(propertyAlertDomain.PersonName);
            response.PropertyReference.Should().Be(propertyAlertDomain.PropertyReference);
            response.Reason.Should().Be(propertyAlertDomain.Reason);
            response.Neighbourhood.Should().Be(propertyAlertDomain.Neighbourhood);
        }


    }
}
