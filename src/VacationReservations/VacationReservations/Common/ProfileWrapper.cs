using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Profile;
using System.Web.Security;

namespace VacationReservations.Common
{
    public class ProfileWrapper
    {
        private string address1;
        private string address2;
        private string city;
        private string region;
        private string postalCode;
        private string country;
        private string shippingRegion;
        private string dayPhone;
        private string evePhone;
        private string mobPhone;
        private string email;
        private string creditCard;
        private string creditCardHolder;
        private string creditCardNumber;
        private string creditCardIssueDate;
        private string creditCardIssueNumber;
        private string creditCardExpiryDate;
        private string creditCardType;

        public string Address1
        {
            get
            {
                return address1;
            }
            set
            {
                address1 = value;
            }
        }
        public string Address2
        {
            get
            {
                return address2;
            }
            set
            {
                address2 = value;
            }
        }
        public string City
        {
            get
            {
                return city;
            }
            set
            {
                city = value;
            }
        }
        public string Region
        {
            get
            {
                return region;
            }
            set
            {
                region = value;
            }
        }
        public string PostalCode
        {
            get
            {
                return postalCode;
            }
            set
            {
                postalCode = value;
            }
        }
        public string Country
        {
            get
            {
                return country;
            }
            set
            {
                country = value;
            }
        }
        public string ShippingRegion
        {
            get
            {
                return shippingRegion;
            }
            set
            {
                shippingRegion = value;
            }
        }
        public string DayPhone
        {
            get
            {
                return dayPhone;
            }
            set
            {
                dayPhone = value;
            }
        }
        public string EvePhone
        {
            get
            {
                return evePhone;
            }
            set
            {
                evePhone = value;
            }
        }
        public string MobPhone
        {
            get
            {
                return mobPhone;
            }
            set
            {
                mobPhone = value;
            }
        }
        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
            }
        }
        public string CreditCard
        {
            get
            {
                return creditCard;
            }
            set
            {
                creditCard = value;
            }
        }
        public string CreditCardHolder
        {
            get
            {
                return creditCardHolder;
            }
            set
            {
                creditCardHolder = value;
            }
        }
        public string CreditCardNumber
        {
            get
            {
                return creditCardNumber;
            }
            set
            {
                creditCardNumber = value;
            }
        }
        public string CreditCardIssueDate
        {
            get
            {
                return creditCardIssueDate;
            }
            set
            {
                creditCardIssueDate = value;
            }
        }
        public string CreditCardIssueNumber
        {
            get
            {
                return creditCardIssueNumber;
            }
            set
            {
                creditCardIssueNumber = value;
            }
        }
        public string CreditCardExpiryDate
        {
            get
            {
                return creditCardExpiryDate;
            }
            set
            {
                creditCardExpiryDate = value;
            }
        }
        public string CreditCardType
        {
            get
            {
                return creditCardType;
            }
            set
            {
                creditCardType = value;
            }
        }

        public ProfileWrapper()
        {
            ProfileBase profile = HttpContext.Current.Profile;
            address1 = (string)profile["Address1"];
            address2 = (string)profile["Address2"];
            city = (string)profile["City"];
            region = (string)profile["Region"];
            postalCode = (string)profile["PostalCode"];
            country = (string)profile["Country"];


            shippingRegion =
            (profile["ShippingRegion"]== null
            || (string)profile["ShippingRegion"] == ""
            ? "1" : (string)profile["ShippingRegion"]);
            dayPhone = (string)profile["DayPhone"];
            evePhone = (string)profile["EvePhone"];
            mobPhone = (string)profile["MobPhone"];
            email = Membership.GetUser(profile.UserName).Email;
            try
            {
                SecureCard secureCard = new SecureCard((string)profile["CreditCard"]);
                creditCard = secureCard.CardNumberX;
                creditCardHolder = secureCard.CardHolder;
                creditCardNumber = secureCard.CardNumber;
                creditCardIssueDate = secureCard.IssueDate;
                creditCardIssueNumber = secureCard.IssueNumber;
                creditCardExpiryDate = secureCard.ExpiryDate;
                creditCardType = secureCard.CardType;
            }
            catch
            {
                creditCard = "Not entered.";
            }
        }
        public void UpdateProfile()
        {
            ProfileBase profile = HttpContext.Current.Profile;
            profile["Address1"] = address1;
            profile["Address2"] = address2;
            profile["City"] = city;
            profile["Region"] = region;
            profile["PostalCode"] = postalCode;
            profile["Country"] = country;
            profile["ShippingRegion"] = shippingRegion;
            profile["DayPhone"] = dayPhone;
            profile["EvePhone"] = evePhone;
            profile["MobPhone"] = mobPhone;
            profile["CreditCard"] = creditCard;
            MembershipUser user = Membership.GetUser(profile.UserName);
            user.Email = email;
            Membership.UpdateUser(user); try
            {
                SecureCard secureCard = new SecureCard(
                creditCardHolder, creditCardNumber,
                creditCardIssueDate, creditCardExpiryDate,
                creditCardIssueNumber, creditCardType);
                profile["CreditCard"] = secureCard.EncryptedData;
            }
            catch
            {
                creditCard = "";
            }
        }
    }
}
    