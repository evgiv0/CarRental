using CoreCommon.Core;

namespace CarRental.Client.Entities
{

    public class Car : ObjectBase
    {
        private int _carId;
        private string _description;
        private string _color;
        private int _year;
        private decimal _rentalPrice;
        private bool _currentlyRented;

        public int CarId
        {
            get => _carId;

            set
            {
                if (_carId != value)
                {
                    _carId = value;
                    OnPropertyChanged(() => CarId);
                }
            }
        }

        private string Description
        {
            get { return _description; }
            set
            {
                if (_description != value)
                {
                    _description = value;
                    OnPropertyChanged(() => Description);
                }
            }
        }

        private string Color
        {
            get { return _color; }
            set
            {
                if (_color != value)
                {
                    _color = value;
                    OnPropertyChanged(() => Color);
                }
            }
        }

        private int Year
        {
            get { return _year; }
            set
            {
                if (_year != value)
                {
                    _year = value;
                    OnPropertyChanged(() => Year);
                }
            }
        }

        private decimal RentalPrice
        {
            get { return _rentalPrice; }
            set
            {
                if (_rentalPrice != value)
                {
                    _rentalPrice = value;
                    OnPropertyChanged(() => RentalPrice);
                }
            }
        }

        private bool CurrentlyRented
        {
            get { return _currentlyRented; }
            set
            {
                if (_currentlyRented != value)
                {
                    _currentlyRented = value;
                    OnPropertyChanged(() => CurrentlyRented);
                }
            }
        }


    }
}
