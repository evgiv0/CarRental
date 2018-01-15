namespace CarRental.Client.Entities
{

    public class Car
    {
        private int _carId;
        private readonly string _description;
        private readonly string _color;
        private readonly int _year;
        private readonly decimal _rentalPrice;
        private readonly bool _currentlyRented;

        private string Description
        {
            get { return _description; }
        }

        private string Color
        {
            get { return _color; }
        }

        private int Year
        {
            get { return _year; }
        }

        private decimal RentalPrice
        {
            get { return _rentalPrice; }
        }

        private bool CurrentlyRented
        {
            get { return _currentlyRented; }
        }

        public int CarId
        {
            get => _carId;

            set => _carId = value;
        }
    }
}
