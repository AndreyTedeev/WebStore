using System;

namespace WebStore
{

    public class Helper
    {

        public static int DateDiffInYears(DateTime start, DateTime end)
        {
            var result = start.Year - end.Year;
            if (end.Date > start.AddYears(-result)) result--;
            return result;
        }

    }
}
