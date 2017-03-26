using System;

namespace Utils
{
    public class DateProvider
    {
        private const int monthsInYear = 12;
        private const double daysToMonths = 30.4368499;

        public static DateTime UtcNow
        {
            get
            {
                return DateTime.UtcNow;
            }
        }

        public static double? ConvertToYears(double? days)
        {
            if (!days.HasValue)
            {
                return null;
            }

            var months = (int)(days / daysToMonths);
            return months / monthsInYear;
        }
    }
}
