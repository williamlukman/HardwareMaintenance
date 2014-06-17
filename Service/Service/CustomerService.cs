using Core.DomainModel;
using Core.Interface.Repository;
using Core.Interface.Service;
using Core.Interface.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service
{
    public class CustomerService : ICustomerService
    {
        private ICustomerRepository _repository;
        private ICustomerValidator _validator;
        public CustomerService(ICustomerRepository _customerRepository, ICustomerValidator _customerValidator)
        {
            _repository = _customerRepository;
            _validator = _customerValidator;
        }

        public ICustomerValidator GetValidator()
        {
            return _validator;
        }

        public IList<Customer> GetAll()
        {
            return _repository.GetAll();
        }

        public Customer GetObjectById(int Id)
        {
            return _repository.GetObjectById(Id);
        }

        public Customer GetObjectByName(string name)
        {
            return _repository.FindAll(c => c.Name == name && !c.IsDeleted).FirstOrDefault();
        }

        public Customer CreateObject(string Name, string Address, string PIC, string Contact, string Email)
        {
            Customer customer = new Customer
            {
                Name = Name,
                Address = Address,
                PIC = PIC,
                Contact = Contact,
                Email = Email
            };
            return this.CreateObject(customer);
        }

        public Customer CreateObject(Customer customer)
        {
            customer.Errors = new Dictionary<String, String>();
            return (_validator.ValidCreateObject(customer, this) ? _repository.CreateObject(customer) : customer);
        }

        public Customer UpdateObject(Customer customer)
        {
            return (customer = _validator.ValidUpdateObject(customer, this) ? _repository.UpdateObject(customer) : customer);
        }

        public Customer SoftDeleteObject(Customer customer, IItemService _itemService, IMaintenanceService _maintenanceService)
        {
            return (customer = _validator.ValidDeleteObject(customer, _itemService, _maintenanceService) ? _repository.SoftDeleteObject(customer) : customer);
        }

        public bool DeleteObject(int Id)
        {
            return _repository.DeleteObject(Id);
        }

        public bool IsNameDuplicated(Customer customer)
        {
            IQueryable<Customer> customers = _repository.FindAll(x => x.Name == customer.Name && !x.IsDeleted && x.Id != customer.Id);
            return (customers.Count() > 0 ? true : false);
        }

    }
}