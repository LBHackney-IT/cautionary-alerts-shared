using AutoFixture;
using Hackney.Shared.CautionaryAlerts.Infrastructure;
using Hackney.Shared.CautionaryAlerts.Factories;
using FluentAssertions;
using NUnit.Framework;
using System.Linq;
using System;
using Hackney.Shared.CautionaryAlerts.Boundary.Request;
using Hackney.Shared.CautionaryAlerts.Infrastructure.GoogleSheets;

namespace Hackney.Shared.CautionaryAlerts.Tests.Factories
{
    [TestFixture]
    public class EntityFactoryTest
    {
        private readonly Fixture _fixture = new Fixture();

        [Test]
        public void CanMapAPersonAlertToCautionaryAlertWithDescription()
        {
            // Arrange
            var entity = _fixture.Create<PersonAlert>();
            var description = _fixture.Create<string>();

            // Act
            var response = entity.ToDomain(description);

            // Assert
            response.Description.Should().Be(description);
            response.AlertCode.Should().Be(entity.AlertCode);
            response.DateModified.Should().Be(entity.DateModified);
            response.EndDate.Should().Be(entity.EndDate);
            response.StartDate.Should().Be(entity.StartDate);
            response.ModifiedBy.Should().Be(entity.ModifiedBy);
        }

        [Test]
        public void CanMapRowsToCautionaryAlertListItem()
        {
            // Arrange
            var numColumns = 16;
            var row = _fixture.CreateMany<string>(numColumns).ToList();

            // Act
            var result = EntityFactory.ToModel(row);

            // Assert
            result.Name.Should().Be(row[0]);
            result.DoorNumber.Should().Be(row[1]);
            result.Address.Should().Be(row[2]);
            result.Neighbourhood.Should().Be(row[3]);
            result.DateOfIncident.Should().Be(row[4]);
            result.NumberOfDaysOutstanding.Should().Be(row[5]);
            result.Code.Should().Be(row[6]);
            result.LetterSent.Should().Be(row[7]);
            result.OnCivica.Should().Be(row[8]);
            result.Outcome.Should().Be(row[9]);
            result.CautionOnSystem.Should().Be(row[10]);
            result.ActionOnAssure.Should().Be(row[11]);
            result.Lookup.Should().Be(row[12]);
            result.PropertyReference.Should().Be(row[13]);
            result.TenancyDates.Should().Be(row[14]);
            result.IncidentBeforeCurrentTenancyDate.Should().Be(row[15]);
        }

        [Test]
        public void DoesntThrowIndexOutOfRangeExceptionWhenMissingColumns()
        {
            // Arrange
            var numColumns = 16;
            var realNumColumns = numColumns - 1;

            var row = _fixture.CreateMany<string>(realNumColumns).ToList();

            // Act
            Func<CautionaryAlertListItem> task = () => EntityFactory.ToModel(row);

            // Assert
            task.Should().NotThrow<IndexOutOfRangeException>();
        }

        [Test]
        public void CanCreateAPropertyAlertDomainObjectFromPropertyAlertNew()
        {
            // Arrange
            var alertId = _fixture.Create<string>();
            var propertyAlertNew = _fixture.Create<PropertyAlertNew>();
            propertyAlertNew.AlertId = alertId;

            // Act
            var response = propertyAlertNew.ToDomain();

            // Assert
            response.DoorNumber.Should().Be(propertyAlertNew.DoorNumber);
            response.Address.Should().Be(propertyAlertNew.Address);
            response.Neighbourhood.Should().Be(propertyAlertNew.Neighbourhood);
            response.DateOfIncident.Should().Be(propertyAlertNew.DateOfIncident);
            response.Code.Should().Be(propertyAlertNew.Code);
            response.CautionOnSystem.Should().Be(propertyAlertNew.CautionOnSystem);
            response.PropertyReference.Should().Be(propertyAlertNew.PropertyReference);
            response.Name.Should().Be(propertyAlertNew.PersonName);
            response.Reason.Should().Be(propertyAlertNew.Reason);
            response.AssureReference.Should().Be(propertyAlertNew.AssureReference);
            response.PersonId.Should().Be(propertyAlertNew.MMHID);
            response.AlertId.Should().Be(propertyAlertNew.AlertId);
            response.IsActive.Should().Be(propertyAlertNew.IsActive);
        }

        [Test]
        public void CanCreatePropertyAlertNewFromCreateCautionaryAlert()
        {
            // Arrange
            var alertId = _fixture.Create<string>();
            var isActive = _fixture.Create<bool>();
            var entity = _fixture.Create<CreateCautionaryAlert>();
            entity.IncidentDate = new DateTime(2020, 1, 1);

            // Act
            var response = entity.ToDatabase(isActive, alertId);

            // Assert
            response.AssureReference.Should().Be(entity.AssureReference);
            response.Address.Should().Be(entity.AssetDetails?.FullAddress);
            response.UPRN.Should().Be(entity.AssetDetails?.UPRN);
            response.PropertyReference.Should().Be(entity.AssetDetails?.PropertyReference);
            response.MMHID.Should().Be(entity.PersonDetails.Id.ToString());
            response.PersonName.Should().Be(entity.PersonDetails.Name);
            response.Code.Should().Be(entity.Alert.Code);
            response.CautionOnSystem.Should().Be(entity.Alert.Description);
            response.DateOfIncident.Should().Be("01/01/2020");
            response.Reason.Should().Be(entity.IncidentDescription);
            response.AlertId.Should().Be(alertId);
            response.IsActive.Should().Be(isActive);
        }
    }
}
