using System;
using System.Collections.Generic;

namespace Movies.Services
{
    public static class RoundingUtils
    {
        public static double RoundToNearestDot5(double? input)
        {
            if (input.HasValue == false)
                return 0;
            var doubleValue = input.Value * 2;
            return Math.Round(doubleValue, MidpointRounding.AwayFromZero) / 2;
        }
    }
}
