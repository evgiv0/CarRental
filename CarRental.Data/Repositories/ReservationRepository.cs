using CarRental.Business.Entities;
using System.Collections.Generic;
using System.Linq;

namespace CarRental.Data.Repositories
{
    public class ReservationRepository : DataRepositoryBase<Reservation>
    {
        protected override Reservation AddEntity(CarRentalContext entityContext, Reservation entity)
        {
            return entityContext.ReservationSet.Add(entity);
        }

        protected override Reservation UpdateEntity(CarRentalContext entityContext, Reservation entity)
        {
            return entityContext.ReservationSet.FirstOrDefault(c => c.ReservationId == entity.ReservationId);
        }

        protected override IEnumerable<Reservation> GetEntities(CarRentalContext entityContext)
        {
            return entityContext.ReservationSet;
        }

        protected override Reservation GetEntity(CarRentalContext entityContext, int id)
        {
            return entityContext.ReservationSet.FirstOrDefault(a => a.ReservationId == id);
        }
    }
}
