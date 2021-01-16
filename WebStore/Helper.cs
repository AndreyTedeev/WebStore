using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore
{
    public class Helper
    {

        public static int DateDiffInYears(DateTime start, DateTime end) {
            var result = start.Year - end.Year;
            if (end.Date > start.AddYears(-result)) result--;
            return result;
        }

    }
}
