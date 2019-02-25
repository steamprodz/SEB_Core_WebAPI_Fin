using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEB_Core_WebAPI.Models
{
    public class Question
    {
        //// 0 - 17, 18 - 64, 65+
        //public enum AgeType { ZeroToSeventeen, EighteenToSixtyFour, SixtyFivePlus }
        //// 0, 1 - 12000, 12001 - 40000, 40001+
        //public enum IncomeType { Zero, OneToTwelveTh, TwelveThToFourtyThAndOne, FourtyThAndOnePlus }

        public int QuestionId { get; set; }
        public int Age { get; set; }
        //public AgeType Age { get; set; }
        public bool IsStudent { get; set; }
        public long Income { get; set; }
        //public IncomeType Income { get; set; }
    }
}
