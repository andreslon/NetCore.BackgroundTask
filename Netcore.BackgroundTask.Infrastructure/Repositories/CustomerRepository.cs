using Netcore.BackgroundTask.Core.Entities;
using Netcore.BackgroundTask.Core.Interfaces;
using System;

namespace Netcore.BackgroundTask.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        public bool Create(Customer entity)
        {
            //Created
            return true;
        }

        public bool Delete(Customer entity)
        {
            //Deleted
            return true;
        }

        public Customer GetById(Guid id)
        {
            //Found
            return new Customer(id)
            {
                Name = "Andres",
                LastName = "Londoño"
            };
        }

        public bool Update(Customer entity)
        {
            //Updated
            return true;
        }
    }
}
