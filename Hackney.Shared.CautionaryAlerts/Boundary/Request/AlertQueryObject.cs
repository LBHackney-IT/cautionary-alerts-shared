﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace Hackney.Shared.CautionaryAlerts.Boundary.Request
{
    public class AlertQueryObject
    {
        [FromRoute(Name = "personId")]
        public Guid PersonId { get; set; }

        [FromRoute(Name = "alertId")]
        public Guid AlertId { get; set; }
    }
}