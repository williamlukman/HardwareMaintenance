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
    public class UserService : IUserService
    {
        private IUserRepository _repository;
        private IUserValidator _validator;
        public UserService(IUserRepository _userRepository, IUserValidator _userValidator)
        {
            _repository = _userRepository;
            _validator = _userValidator;
        }

        public IUserValidator GetValidator()
        {
            return _validator;
        }

        public IList<User> GetAll()
        {
            return _repository.GetAll();
        }

        public User GetObjectById(int Id)
        {
            return _repository.GetObjectById(Id);
        }

        public User GetObjectByName(string name)
        {
            return _repository.FindAll(u => u.Name == name && !u.IsDeleted).FirstOrDefault();
        }

        public User CreateObject(string Name, string Description)
        {
            User user = new User
            {
                Name = Name,
                Description = Description
            };
            return this.CreateObject(user);
        }

        public User CreateObject(User user)
        {
            user.Errors = new Dictionary<String, String>();
            return (_validator.ValidCreateObject(user) ? _repository.CreateObject(user) : user);
        }

        public User UpdateObject(User user)
        {
            return (user = _validator.ValidUpdateObject(user) ? _repository.UpdateObject(user) : user);
        }

        public User SoftDeleteObject(User user, IMaintenanceService _maintenanceService)
        {
            return (user = _validator.ValidDeleteObject(user, _maintenanceService) ? _repository.SoftDeleteObject(user) : user);
        }

        public bool DeleteObject(int Id)
        {
            return _repository.DeleteObject(Id);
        }
    }
}