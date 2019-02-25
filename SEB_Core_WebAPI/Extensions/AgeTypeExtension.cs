using SEB_Core_WebAPI.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEB_Core_WebAPI.Extensions
{
    public static class AgeTypeExtension
    {
        public static AgeType ToEnum(this int age)
        {
            switch (age)
            {
                case int n when (n >= 0 && n <= 17):
                    return AgeType.ZeroToSeventeen;

                case int n when (n >= 18 && n <= 64):
                    return AgeType.EighteenToSixtyFour;

                case int n when (n >= 65):
                    return AgeType.SixtyFivePlus;

                default:
                    return AgeType.EighteenToSixtyFour;
            }
        }
    }
}
