using System;

namespace PriceGetter.Core.DateTimeAbstraction
{
    public static class DateTimeMethods
    {
        public static IDateTimeProvider DateTimeProvider = new DateTimeProvider();

        public static DateTime UtcNow()
        {
            return DateTimeProvider.UtcNow();
        }

        public static void OverrideDateTimeProvider(IDateTimeProvider newProvider)
        {
            DateTimeProvider = newProvider;
        }
    }
}