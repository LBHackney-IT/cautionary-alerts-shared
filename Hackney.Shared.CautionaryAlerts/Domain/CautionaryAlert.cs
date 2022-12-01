using System;

namespace Hackney.Shared.CautionaryAlerts.Domain
{
    public class CautionaryAlert
    {
        public DateTime DateModified { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string AlertCode { get; set; }

        public string Description { get; set; }
    }
}
