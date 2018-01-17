using CarRental.Business.Entities;
using Core.Common.Contracts;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Runtime.Serialization;

namespace CarRental.Data
{
    public class CarRentalContext : DbContext
    {
        public CarRentalContext() : base("name=CarRental")
        {
            Database.SetInitializer<CarRentalContext>(null);
        }

        public DbSet<Car> CarSet { get; set; }
        public DbSet<Account> AccountSet { get; set; }
        public DbSet<Rental> RentalSet { get; set; }
        public DbSet<Reservation> ReservationSet { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove(new PluralizingTableNameConvention());

            modelBuilder.Ignore<ExtensionDataObject>();
            modelBuilder.Ignore<IIdentifiableEntity>();

            modelBuilder.Entity<Car>()
                .HasKey<int>(car => car.CarId)
                .Ignore(e => e.EntityId)
                .Ignore(e => e.CurrentlyRented);

            modelBuilder.Entity<Account>()
                .HasKey<int>(car => car.AccountId)
                .Ignore(e => e.EntityId);

            modelBuilder.Entity<Reservation>()
                .HasKey<int>(car => car.ReservationId)
                .Ignore(e => e.EntityId);

            modelBuilder.Entity<Rental>()
                .HasKey<int>(car => car.RentalId)
                .Ignore(e => e.EntityId);

            modelBuilder.Entity<Account>().ToTable("User");

        }
    }
}
