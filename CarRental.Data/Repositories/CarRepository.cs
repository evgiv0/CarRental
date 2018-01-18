using CarRental.Business.Entities;
using System.Collections.Generic;
using System.Linq;

namespace CarRental.Data.Repositories
{
    public class CarRepository : DataRepositoryBase<Car>
    {
        protected override Car AddEntity(CarRentalContext entityContext, Car entity)
        {
            return entityContext.CarSet.Add(entity);
        }

        protected override Car UpdateEntity(CarRentalContext entityContext, Car entity)
        {
            return entityContext.CarSet.FirstOrDefault(c => c.CarId == entity.CarId);
        }

        protected override IEnumerable<Car> GetEntities(CarRentalContext entityContext)
        {
            return entityContext.CarSet;
        }

        protected override Car GetEntity(CarRentalContext entityContext, int id)
        {
            return entityContext.CarSet.FirstOrDefault(a => a.CarId == id);
        }
    }
}
