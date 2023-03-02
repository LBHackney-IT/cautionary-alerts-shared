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
        public string AssureReference { get; set; }
        public string PersonName { get; set; }
        public Guid PersonId { get; set; }
        public bool IsActive { get; set; }
    }
}
