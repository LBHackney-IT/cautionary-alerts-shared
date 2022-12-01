using System.Collections.Generic;

namespace Hackney.Shared.CautionaryAlerts.Boundary.Response
{
    public class CautionaryAlertsGoogleSheetPersonResponse
    {
        /// <summary>
        /// A unique MMH identifier (GUID) of a person
        /// </summary>
        public string PersonId { get; set; }

        /// <summary>
        /// A list of cautionary alerts for a person with <see cref="PersonId"/>
        /// </summary>
        public List<CautionaryAlertGoogleSheetResponse> Alerts { get; set; }
    }
}
