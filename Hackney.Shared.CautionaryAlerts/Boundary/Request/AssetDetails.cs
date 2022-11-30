using System;

namespace Hackney.Shared.CautionaryAlerts.Boundary.Request
{
    public class AssetDetails
    {
        public Guid Id { get; set; }
        public string PropertyReference { get; set; }
        public string UPRN { get; set; }
        public string FullAddress { get; set; }
    }
}
