using CarRental.Business.Entities;
using CarRental.Data.Contracts.Repository_Interfaces;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;

namespace CarRental.Data.Repositories
{
    [Export(typeof(IAccountRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class AccountRepository : DataRepositoryBase<Account>, IAccountRepository
    {
        protected override Account AddEntity(CarRentalContext entityContext, Account entity)
        {
            return entityContext.AccountSet.Add(entity);
        }

        protected override Account UpdateEntity(CarRentalContext entityContext, Account entity)
        {
            return entityContext.AccountSet.FirstOrDefault(a => a.AccountId == entity.AccountId);
        }

        protected override IEnumerable<Account> GetEntities(CarRentalContext entityContext)
        {
            return entityContext.AccountSet;
        }

        protected override Account GetEntity(CarRentalContext entityContext, int id)
        {
            return entityContext.AccountSet.FirstOrDefault(a => a.AccountId == id);
        }

        public Account GetByLogin(string login)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                return context.AccountSet.FirstOrDefault(a => a.LoginEmail == login);
            }
        }
    }
}
