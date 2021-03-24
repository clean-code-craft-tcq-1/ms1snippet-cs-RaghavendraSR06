using System.Collections.Generic;

namespace SensorValidate
{
    public class SensorValidator
    {
        public static bool IsDeltaValueBreached(double value, double nextValue, double maxDelta)
        {
            return !(nextValue - value > maxDelta);
        }

        public static bool ValidateSocReadings(List<double> socValues)
        {
            const double maxSocDelta = 0.05;
            return ValidateSensorReadings(socValues, maxSocDelta);
        }

        public static bool ValidateCurrentReadings(List<double> currentValues)
        {
            const double maxCurrentDelta = 0.05;
            return ValidateSensorReadings(currentValues, maxCurrentDelta);
        }

        private static bool ValidateSensorReadings(List<double> values,double maxDelta)
        {
            return ValidateReadingValues(values) && ValidateDeltaValue(values, maxDelta);
        }

        private static bool ValidateDeltaValue(List<double> values, double maxDelta)
        {
            for (int i = 0; i < values.Count - 1; i++)
            {
                if (!IsDeltaValueBreached(values[i], values[i + 1], maxDelta))
                {
                    return false;
                }
            }

            return true;
        }

        private static bool ValidateReadingValues(List<double> values)
        {
            return values != null && values.Count > 0;
        }
    }
}
