using Core.DomainModel;
using Core.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Context;
using Data.Repository;
using System.Data;

namespace Data.Repository
{
    public class CustomerRepository : EfRepository<Customer>, ICustomerRepository
    {

        private HardwareMaintenanceEntities entities;
        public CustomerRepository()
        {
            entities = new HardwareMaintenanceEntities();
        }

        public IList<Customer> GetAll()
        {
            return FindAll().ToList();
        }

        public Customer GetObjectById(int Id)
        {
            Customer customer = Find(x => x.Id == Id && !x.IsDeleted);
            if (customer != null) { customer.Errors = new Dictionary<string, string>(); }
            return customer;
        }

        public Customer CreateObject(Customer customer)
        {
            customer.IsDeleted = false;
            customer.CreatedAt = DateTime.Now;
            return Create(customer);
        }

        public Customer UpdateObject(Customer customer)
        {
            customer.UpdatedAt = DateTime.Now;
            Update(customer);
            return customer;
        }

        public Customer SoftDeleteObject(Customer customer)
        {
            customer.IsDeleted = true;
            customer.DeletedAt = DateTime.Now;
            Update(customer);
            return customer;
        }

        public bool DeleteObject(int Id)
        {
            Customer customer = Find(x => x.Id == Id);
            return (Delete(customer) == 1) ? true : false;
        }
    }
}