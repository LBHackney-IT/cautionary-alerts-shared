using System;
using System.Collections.Generic;

namespace Hackney.Shared.CautionaryAlerts.Domain
{
    public class CautionaryAlertsProperty
    {
        public string PropertyReference { get; set; }
        public string UPRN { get; set; }
        public string AddressNumber { get; set; }
        public List<CautionaryAlert> Alerts { get; set; }
        public string AssureReference { get; set; }
        public string PersonName { get; set; }
        public Guid PersonId { get; set; }
    }
}
