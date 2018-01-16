using CoreCommon.Core;
using System;

namespace CarRental.Client.Entities
{
    public class Reservation : ObjectBase
    {
        private int _reservationId;
        private int _accountId;
        private int _carId;
        private DateTime _rentalDate;
        private DateTime _returnDate;

        public int ReservationId
        {
            get => _reservationId;

            set
            {
                if (_reservationId != value)
                {
                    _reservationId = value;
                    OnPropertyChanged(() => ReservationId);
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

        private DateTime RentalDate
        {
            get { return _rentalDate; }
            set
            {
                if (_rentalDate != value)
                {
                    _rentalDate = value;
                    OnPropertyChanged(() => RentalDate);
                }
            }
        }

        private DateTime ReturnDate
        {
            get { return _returnDate; }
            set
            {
                if (_returnDate != value)
                {
                    _returnDate = value;
                    OnPropertyChanged(() => ReturnDate);
                }
            }
        }
    }
}
