using System;
using System.Collections.Generic;

namespace Hackney.Shared.CautionaryAlerts.Boundary.Response
{
    public class CautionaryAlertsPropertyResponse
    {
        public string PropertyReference { get; set; }
        public string UPRN { get; set; }
        public string AddressNumber { get; set; }
        public List<CautionaryAlertResponse> Alerts { get; set; }

    }
}
