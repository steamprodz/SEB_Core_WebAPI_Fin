using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEB_Core_WebAPI.Enums
{
    // 0, 1 - 12000, 12001 - 40000, 40001+
    public enum IncomeType
    {
        Zero,
        OneToTwelveTh,
        TwelveThAndOneToFourtyTh,
        FourtyThAndOnePlus
    }
}
