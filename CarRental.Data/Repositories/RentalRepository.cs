using CarRental.Business.Entities;
using CarRental.Data.Contracts.Repository_Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace CarRental.Data.Repositories
{
    public class RentalRepository : DataRepositoryBase<Rental>, IRentalRepository
    {
        protected override Rental AddEntity(CarRentalContext entityContext, Rental entity)
        {
            return entityContext.RentalSet.Add(entity);
        }

        protected override Rental UpdateEntity(CarRentalContext entityContext, Rental entity)
        {
            return entityContext.RentalSet.FirstOrDefault(c => c.RentalId == entity.RentalId);
        }

        protected override IEnumerable<Rental> GetEntities(CarRentalContext entityContext)
        {
            return entityContext.RentalSet;
        }

        protected override Rental GetEntity(CarRentalContext entityContext, int id)
        {
            return entityContext.RentalSet.FirstOrDefault(a => a.RentalId == id);
        }

        public IEnumerable<Rental> GetRentalHistoryByCar(int carId)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                return context.RentalSet.Where(r => r.CarId == carId);
            }
        }

        public Rental GetCurrentRentalByCar(int carId)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                return context.RentalSet.FirstOrDefault(r => r.CarId == carId && r.DateReturned == null);
            }
        }

        public IEnumerable<Rental> GetCurrentlyRentedCars()
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                return context.RentalSet.Where(r => r.DateReturned == null);
            }
        }

        public IEnumerable<Rental> GetRentalHistoryByAccount(int accountId)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                return context.RentalSet.Where(r => r.AccountId == accountId);
            }
        }
    }
}
