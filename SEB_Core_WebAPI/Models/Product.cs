using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEB_Core_WebAPI.Models
{
    public class Product
    {
        //public enum AccountType { Current, CurrentPlus, JuniorSaver, Student }
        //public enum CardType { Debit, Credit, GoldCredit }
        //public enum AccountCardType { CurrentAccount, CurrentPlusAccount, JuniorSaverAccount, StudentAccount, DebitCard, CreditCard, GoldCreditCard }

        public int ProductId { get; set; }
        public string Name { get; set; }
        //public AccountCardType ProductType { get; set; }
        //public AccountType Account { get; set; }
        //public CardType Card { get; set; }
    }
}
