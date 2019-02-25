using SEB_Core_WebAPI.Enums;

namespace SEB_Core_WebAPI.ViewModels
{
    public class ProductViewModel
    {
        //public enum AccountCardType { CurrentAccount, CurrentPlusAccount, JuniorSaverAccount, StudentAccount, DebitCard, CreditCard, GoldCreditCard }

        public long Id { get; set; }
        public AccountCardType TypeName { get; set; }
    }
}
