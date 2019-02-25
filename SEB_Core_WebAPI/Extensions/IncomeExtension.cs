using SEB_Core_WebAPI.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEB_Core_WebAPI.Extensions
{
    public static class IncomeExtension
    {
        public static IncomeType ToEnum(this long income)
        {
            switch (income)
            {
                case 0:
                    return IncomeType.Zero;

                case long n when (n >= 1 && n <= 12000):
                    return IncomeType.OneToTwelveTh;

                case long n when (n >= 12001 && n <= 40000):
                    return IncomeType.TwelveThAndOneToFourtyTh;

                case long n when (n >= 40001):
                    return IncomeType.FourtyThAndOnePlus;

                default:
                    return IncomeType.Zero;
            }
        }
    }
}
