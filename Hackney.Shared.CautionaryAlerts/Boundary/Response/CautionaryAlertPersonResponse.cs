using System.Collections.Generic;

namespace Hackney.Shared.CautionaryAlerts.Boundary.Response
{
    public class CautionaryAlertPersonResponse
    {
        /// <example>7498659/01</example>
        /// <summary>Tenancy Reference</summary>
        public string TenancyAgreementReference { get; set; }
        /// <example>02</example>
        /// <summary>Specific person number within the tenancy</summary>
        public string PersonNumber { get; set; }
        /// <example>351768</example>
        /// <summary>UH identifier for the persons cautionary alert</summary>
        public string ContactNumber { get; set; }
        public List<CautionaryAlertResponse> Alerts { get; set; }
    }

    public class ListPersonsCautionaryAlerts
    {
        public List<CautionaryAlertPersonResponse> Contacts { get; set; }
    }
}
