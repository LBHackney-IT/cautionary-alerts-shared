using System.Collections.Generic;

namespace Hackney.Shared.CautionaryAlerts.Domain
{
    public class CautionaryAlertPerson
    {
        public string TagRef { get; set; }
        public string PersonNumber { get; set; }
        public string ContactNumber { get; set; }
        public List<CautionaryAlert> Alerts { get; set; }
    }
}
