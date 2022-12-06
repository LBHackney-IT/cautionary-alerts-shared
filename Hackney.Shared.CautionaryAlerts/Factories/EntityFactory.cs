using Hackney.Shared.CautionaryAlerts.Boundary.Request;
using Hackney.Shared.CautionaryAlerts.Domain;
using Hackney.Shared.CautionaryAlerts.Infrastructure;
using Hackney.Shared.CautionaryAlerts.Infrastructure.GoogleSheets;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using PropertyAlert = Hackney.Shared.CautionaryAlerts.Infrastructure.PropertyAlert;

namespace Hackney.Shared.CautionaryAlerts.Factories
{
    public static class EntityFactory
    {
        public static CautionaryAlert ToDomain(this PersonAlert alert, string description)
        {
            return new CautionaryAlert
            {
                Description = description,
                AlertCode = alert.AlertCode,
                DateModified = alert.DateModified,
                EndDate = alert.EndDate,
                StartDate = alert.StartDate,
                ModifiedBy = alert.ModifiedBy
            };
        }
        public static CautionaryAlert ToDomain(this PropertyAlert alert, string description)
        {
            return new CautionaryAlert
            {
                Description = description,
                AlertCode = alert.AlertCode,
                DateModified = alert.DateModified,
                EndDate = alert.EndDate,
                StartDate = alert.StartDate,
                ModifiedBy = alert.ModifiedBy
            };
        }

        public static CautionaryAlertListItem ToModel(this IEnumerable<string> row)
        {
            var rowArray = row.ToArray();

            return new CautionaryAlertListItem
            {
                Name = ReadColumn(rowArray, 0),
                DoorNumber = ReadColumn(rowArray, 1),
                Address = ReadColumn(rowArray, 2),
                Neighbourhood = ReadColumn(rowArray, 3),
                DateOfIncident = ReadColumn(rowArray, 4),
                NumberOfDaysOutstanding = ReadColumn(rowArray, 5),
                Code = ReadColumn(rowArray, 6),
                LetterSent = ReadColumn(rowArray, 7),
                OnCivica = ReadColumn(rowArray, 8),
                Outcome = ReadColumn(rowArray, 9),
                CautionOnSystem = ReadColumn(rowArray, 10),
                ActionOnAssure = ReadColumn(rowArray, 11),
                Lookup = ReadColumn(rowArray, 12),
                PropertyReference = ReadColumn(rowArray, 13),
                TenancyDates = ReadColumn(rowArray, 14),
                IncidentBeforeCurrentTenancyDate = ReadColumn(rowArray, 15)
            };
        }

        public static CautionaryAlertListItem ToDomain(this PropertyAlertNew entity)
        {
            return new CautionaryAlertListItem
            {
                DoorNumber = entity.DoorNumber,
                Address = entity.Address,
                Neighbourhood = entity.Neighbourhood,
                DateOfIncident = entity.DateOfIncident,
                Code = entity.Code,
                CautionOnSystem = entity.CautionOnSystem,
                PropertyReference = entity.PropertyReference,
                Name = entity.PersonName,
                Reason = entity.Reason,
                AssureReference = entity.AssureReference
            };
        }

        public static PropertyAlertNew ToDatabase(this CreateCautionaryAlert entity)
        {
            return new PropertyAlertNew()
            {
                AssureReference = entity.AssureReference,
                Address = entity.AssetDetails?.FullAddress,
                UPRN = entity.AssetDetails?.UPRN,
                PropertyReference = entity.AssetDetails?.PropertyReference,
                MMHID = entity.PersonDetails.Id.ToString(),
                PersonName = entity.PersonDetails.Name,
                Code = entity.Alert.Code,
                CautionOnSystem = entity.Alert.Description,
                DateOfIncident = entity.IncidentDate.ToString("d", CultureInfo.InvariantCulture),
                Reason = entity.IncidentDescription
            };
        }

        private static string ReadColumn(string[] rowArray, int index)
        {
            // prevent IndexOutOfRangeException
            if (rowArray.Length < index + 1) return null;

            return rowArray[index];
        }
    }
}
