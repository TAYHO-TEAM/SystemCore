using System;

namespace Services.Common.Utilities
{
    public static class DateTimeHelpers
    {
        public static DateTime TimeStampToDate(double timeStamp)
        {
            timeStamp = timeStamp < 0 ? 0 : timeStamp;
            var date = TimeStampToDateTime(timeStamp);
            return date.Date;
        }

        public static DateTime TimeStampToDateTime(double timeStamp)
        {
            timeStamp = timeStamp < 0 ? 0 : timeStamp;
            DateTimeOffset offset = DateTimeOffset.FromUnixTimeSeconds(Convert.ToInt64(timeStamp));
            return offset.DateTime;
        }

        public static double GetTimeStamp(this DateTime dateTime, bool includedTimeValue = false)
        {
            var date = includedTimeValue ? dateTime : dateTime.Date;
            return Math.Round(date.Subtract(new DateTime(1970, 01, 01)).TotalSeconds, 0);
        }

        public static long ToUnixEpochDate(DateTime date)
        {
            return (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);
        }
    }
}