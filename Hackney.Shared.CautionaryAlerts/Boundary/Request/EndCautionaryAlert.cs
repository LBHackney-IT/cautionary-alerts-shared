using System;
using System.Collections.Generic;
using System.Text;

namespace Hackney.Shared.CautionaryAlerts.Boundary.Request
{
    public class EndCautionaryAlert
    {
        public string AssureReference { get; set; }
        public DateTime IncidentDate { get; set; }
        public string IncidentDescription { get; set; }
        public Alert Alert { get; set; }
        public AssetDetails AssetDetails { get; set; }
        public PersonDetails PersonDetails { get; set; }

        public bool IsActive { get; set; }

        public Guid AlertId { get; set; }
    }
}
