using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpeningHours.Helper
{
    public static class UnixTimeStampHelper
    {
        public static string To12HoursTime(this int value)
        {
            // Unix timestamp is seconds past epoch
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(value);
            return dtDateTime.ToString("hh:mm tt");
        }
    }
}
