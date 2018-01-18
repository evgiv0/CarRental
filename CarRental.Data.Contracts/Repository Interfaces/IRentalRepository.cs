using System.Collections.Generic;
using CarRental.Business.Entities;
using Core.Common.Contracts;

namespace CarRental.Data.Contracts.Repository_Interfaces
{
    public interface IRentalRepository : IDataRepository<Rental>
    {
        IEnumerable<Rental> GetCurrentlyRentedCars();
        Rental GetCurrentRentalByCar(int carId);
        IEnumerable<Rental> GetRentalHistoryByAccount(int accountId);
        IEnumerable<Rental> GetRentalHistoryByCar(int carId);
    }
}