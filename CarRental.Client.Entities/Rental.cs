using CoreCommon.Core;
using System;

namespace CarRental.Client.Entities
{
    public class Rental : ObjectBase
    {
        private int _rentalId;
        private int _accountId;
        private int _carId;
        private DateTime _dateRented;
        private DateTime _dateDue;
        private DateTime _dateReturned;

        public int RentalId
        {
            get => _rentalId;

            set
            {
                if (_rentalId != value)
                {
                    _rentalId = value;
                    OnPropertyChanged(() => RentalId);
                }
            }
        }

        private int AccountId
        {
            get { return _accountId; }
            set
            {
                if (_accountId != value)
                {
                    _accountId = value;
                    OnPropertyChanged(() => AccountId);
                }
            }
        }

        private int CarId
        {
            get { return _carId; }
            set
            {
                if (_carId != value)
                {
                    _carId = value;
                    OnPropertyChanged(() => CarId);
                }
            }
        }

        private DateTime DateRented
        {
            get { return _dateRented; }
            set
            {
                if (_dateRented != value)
                {
                    _dateRented = value;
                    OnPropertyChanged(() => DateRented);
                }
            }
        }

        private DateTime DateDue
        {
            get { return _dateDue; }
            set
            {
                if (_dateDue != value)
                {
                    _dateDue = value;
                    OnPropertyChanged(() => DateDue);
                }
            }
        }

        private DateTime DateReturned
        {
            get { return _dateReturned; }
            set
            {
                if (_dateReturned != value)
                {
                    _dateReturned = value;
                    OnPropertyChanged(() => DateReturned);
                }
            }
        }
    }
}
