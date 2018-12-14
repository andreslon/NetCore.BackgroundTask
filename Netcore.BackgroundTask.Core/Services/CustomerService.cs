using Netcore.BackgroundTask.Core.Entities;
using Netcore.BackgroundTask.Core.Interfaces;
using System;

namespace Netcore.BackgroundTask.Core.Services
{
    public class CustomerService : ICustomerService
    {
        public ICustomerRepository CustomerRepository { get; set; }
        public CustomerService(ICustomerRepository customerRepository)
        {
            CustomerRepository = customerRepository;
        }
        public void  Process()
        { 
            //Example process
            var customer = CustomerRepository.GetById(Guid.NewGuid());
            if (customer != null)
            {
                customer.Name = "Andreslon";
                CustomerRepository.Update(customer);
            }
        }
    }
}
