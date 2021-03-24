using System;
using System.Collections.Generic;

using Xunit;

namespace SensorValidate.Tests
{
    public class SensorValidatorTest
    {
        [Fact]
        public void ReportsErrorWhenSoCJumps() {
            Assert.False(SensorValidator.ValidateSocReadings(
                new List<double>{0.0, 0.01, 0.5, 0.51}
            ));
        }

        [Fact]
        public void ReportsErrorWhenCurrentJumps() {
            Assert.False(SensorValidator.ValidateCurrentReadings(
                new List<double>{0.03, 0.03, 0.03, 0.33}
            ));
        }

        [Fact]
        public void ReportsErrorWhenSocIsNull()
        {
            Assert.False(SensorValidator.ValidateSocReadings(null));
        }

        [Fact]
        public void ReportsErrorWhenCurrentIsNull()
        {
            Assert.False(SensorValidator.ValidateCurrentReadings(null));
        }

        [Fact]
        public void ReportsErrorWhenCurrentHasNoReading()
        {
            Assert.False(SensorValidator.ValidateCurrentReadings(new List<double> { }));
        }

        [Fact]
        public void ReportsErrorWhenSocHasNoReading()
        {
            Assert.False(SensorValidator.ValidateSocReadings(new List<double> { }));
        }

        [Fact]
        public void ReportsNoErrorWhenSoCHasProperReadings()
        {
            Assert.True(SensorValidator.ValidateSocReadings(
                new List<double> { 0.00, 0.01, 0.05, 0.1 }
            ));
        }

        [Fact]
        public void ReportsNoErrorWhenCurrentHasProperReadings()
        {
            Assert.True(SensorValidator.ValidateCurrentReadings(
                new List<double> { 0.3, 0.3, 0.3, 0.33 }
            ));
        }
    }
}
