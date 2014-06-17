using Core.DomainModel;
using Core.Interface.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interface.Service
{
    public interface ICustomerService
    {
        ICustomerValidator GetValidator();
        IList<Customer> GetAll();
        Customer GetObjectById(int Id);
        Customer GetObjectByName(string Name);
        Customer CreateObject(Customer customer);
        Customer UpdateObject(Customer customer);
        Customer SoftDeleteObject(Customer customer);
        bool DeleteObject(int Id);
    }
}