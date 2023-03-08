using FluentAssertions;
using FluentValidation.TestHelper;
using Hackney.Shared.CautionaryAlerts.Boundary.Request;
using Hackney.Shared.CautionaryAlerts.Boundary.Request.Validation;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hackney.Shared.CautionaryAlerts.Tests.Boundary.Validation
{
    [TestFixture]
    public class AlertQueryValidatorTest
    {
        private readonly AlertQueryValidator _classUnderTest;

        public AlertQueryValidatorTest()
        {
            _classUnderTest = new AlertQueryValidator();
        }

        [Test]
        public void AlertIdFailsIfEmpty()
        {
            var model = new AlertQueryObject { AlertId = Guid.Empty };
            var result = _classUnderTest.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.AlertId);

        }

        [Test]
        public void AlertIdNotFailsIfValid()
        {
            var model = new AlertQueryObject { AlertId = Guid.NewGuid() };
            var result = _classUnderTest.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(x => x.AlertId);

        }

        [Test]
        public void PersonIdFailsIfEmpty()
        {
            var model = new AlertQueryObject { PersonId = Guid.Empty };
            var result = _classUnderTest.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.PersonId);

        }

        [Test]
        public void PersonIdShouldNotFailIfValid()
        {
            var model = new AlertQueryObject { PersonId = Guid.NewGuid() };
            var result = _classUnderTest.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(x => x.PersonId);

        }
    }
}
