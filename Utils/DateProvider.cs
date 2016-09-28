using System;

namespace Utils
{
    public static class DateProvider
    {
        private static DateTime utcNow = DateTime.MinValue;
        private static object locker = new object();

        static DateProvider()
        {
        }

        public static DateTime UtcNow
        {
            get
            {
                lock (locker)
                {
                    if (utcNow == DateTime.MinValue)
                    {
                        utcNow = DateTime.UtcNow;
                    }

                    return utcNow;
                }
            }
        }
    }
}
