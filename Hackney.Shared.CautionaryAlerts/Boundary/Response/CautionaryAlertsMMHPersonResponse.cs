using System;
using System.Collections.Generic;

namespace Hackney.Shared.CautionaryAlerts.Boundary.Response
{
    public class CautionaryAlertsMMHPersonResponse
    {
        public Guid PersonId { get; set; }
        public List<CautionaryAlertResponse> Alerts { get; set; }
    }

    public class ListMMHPersonsCautionaryAlerts
    {
        public List<CautionaryAlertPersonResponse> Contacts { get; set; }
    }
}
