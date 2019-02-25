using SEB_Core_WebAPI.Enums;

namespace SEB_Core_WebAPI.ViewModels
{
    public class QuestionViewModel
    {
        //// 0 - 17, 18 - 64, 65+
        //public enum AgeType { ZeroToSeventeen, EighteenToSixtyFour, SixtyFivePlus }
        //// 0, 1 - 12000, 12001 - 40000, 40001+
        //public enum IncomeType { Zero, OneToTwelveTh, TwelveThToFourtyThAndOne, FourtyThAndOnePlus }

        public long Id { get; set; }
        public AgeType Age { get; set; }
        public bool IsStudent { get; set; }
        public IncomeType Income { get; set; }
    }
}
