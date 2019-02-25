using SEB_Core_WebAPI.Enums;
using SEB_Core_WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEB_Core_WebAPI.Extensions
{
    public static class AccountCardTypeExtension
    {
        public static AccountCardType ToEnum(this string typeName)
        {
            switch (typeName)
            {
                case "Current Account":
                    return AccountCardType.CurrentAccount;

                case "Current Account Plus":
                    return AccountCardType.CurrentPlusAccount;

                case "Junior Saver Account":
                    return AccountCardType.JuniorSaverAccount;

                case "Student Account":
                    return AccountCardType.StudentAccount;

                case "Debit Card":
                    return AccountCardType.DebitCard;

                case "Credit Card":
                    return AccountCardType.CreditCard;

                case "Gold Credit Card":
                    return AccountCardType.GoldCreditCard;

                default:
                    return AccountCardType.CurrentAccount;
            }
        }
    }
}