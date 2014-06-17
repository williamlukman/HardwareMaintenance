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

        public IList<DbUser> GetAll()
        {
            return _repository.GetAll();
        }

        public DbUser GetObjectById(int Id)
        {
            return _repository.GetObjectById(Id);
        }

        public DbUser GetObjectByName(string name)
        {
            return _repository.FindAll(u => u.Name == name && !u.IsDeleted).FirstOrDefault();
        }

        public DbUser CreateObject(string Name, string Description)
        {
            DbUser user = new DbUser
            {
                Name = Name,
                Description = Description
            };
            return this.CreateObject(user);
        }

        public DbUser CreateObject(DbUser user)
        {
            user.Errors = new Dictionary<String, String>();
            return (_validator.ValidCreateObject(user, this) ? _repository.CreateObject(user) : user);
        }

        public DbUser UpdateObject(DbUser user)
        {
            return (user = _validator.ValidUpdateObject(user, this) ? _repository.UpdateObject(user) : user);
        }

        public DbUser SoftDeleteObject(DbUser user, IMaintenanceService _maintenanceService)
        {
            return (user = _validator.ValidDeleteObject(user, _maintenanceService) ? _repository.SoftDeleteObject(user) : user);
        }

        public bool DeleteObject(int Id)
        {
            return _repository.DeleteObject(Id);
        }

        public bool IsNameDuplicated(DbUser user)
        {
            IQueryable<DbUser> users = _repository.FindAll(x => x.Name == user.Name && !x.IsDeleted && x.Id != user.Id);
            return (users.Count() > 0 ? true : false);
        }

    }
}