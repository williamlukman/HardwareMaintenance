using Core.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interface.Repository
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        IList<Customer> GetAll();
        Customer GetObjectById(int Id);
        Customer CreateObject(Customer customer);
        Customer UpdateObject(Customer customer);
        Customer SoftDeleteObject(Customer customer);
        bool DeleteObject(int Id);
    }
}