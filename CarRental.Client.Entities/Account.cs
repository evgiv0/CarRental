using CoreCommon.Core;
using System;

namespace CarRental.Client.Entities
{
    public class Account : ObjectBase
    {
        private int _accountId;
        private string _loginEmail;
        private string _lastName;
        private string _firstName;
        private string _address;
        private string _city;
        private string _state;
        private string _zipCode;
        private string _creditCard;
        private DateTime _expDate;


        public int AccountId
        {
            get => _accountId;

            set
            {
                if (_accountId != value)
                {
                    _accountId = value;
                    OnPropertyChanged(() => AccountId);
                }
            }
        }

        private string LoginEmail
        {
            get { return _loginEmail; }
            set
            {
                if (_loginEmail != value)
                {
                    _loginEmail = value;
                    OnPropertyChanged(() => LoginEmail);
                }
            }
        }

        private string LastName
        {
            get { return _lastName; }
            set
            {
                if (_lastName != value)
                {
                    _lastName = value;
                    OnPropertyChanged(() => LastName);
                }
            }
        }

        private string FirstName
        {
            get { return _firstName; }
            set
            {
                if (_firstName != value)
                {
                    _firstName = value;
                    OnPropertyChanged(() => FirstName);
                }
            }
        }

        private string Address
        {
            get { return _address; }
            set
            {
                if (_address != value)
                {
                    _address = value;
                    OnPropertyChanged(() => Address);
                }
            }
        }

        private string City
        {
            get { return _city; }
            set
            {
                if (_city != value)
                {
                    _city = value;
                    OnPropertyChanged(() => City);
                }
            }
        }

        public string State
        {
            get => _state;

            set
            {
                if (_state != value)
                {
                    _state = value;
                    OnPropertyChanged(() => State);
                }
            }
        }

        public string ZipCode
        {
            get => _zipCode;

            set
            {
                if (_zipCode != value)
                {
                    _zipCode = value;
                    OnPropertyChanged(() => ZipCode);
                }
            }
        }

        public string CreditCard
        {
            get => _creditCard;

            set
            {
                if (_creditCard != value)
                {
                    _creditCard = value;
                    OnPropertyChanged(() => CreditCard);
                }
            }
        }

        public DateTime ExpDate
        {
            get => _expDate;

            set
            {
                if (_expDate != value)
                {
                    _expDate = value;
                    OnPropertyChanged(() => ExpDate);
                }
            }
        }
    }
}
