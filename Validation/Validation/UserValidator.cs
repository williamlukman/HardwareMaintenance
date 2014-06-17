using Core.DomainModel;
using Core.Interface.Validation;
using Core.Interface.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Validation.Validation
{
    public class UserValidator : IUserValidator
    {

        public DbUser VName(DbUser user, IUserService _userService)
        {
            if (String.IsNullOrEmpty(user.Name) || user.Name.Trim() == "")
            {
                user.Errors.Add("Name", "Tidak boleh kosong");
            }
            if (_userService.IsNameDuplicated(user))
            {
                user.Errors.Add("Name", "Tidak boleh diduplikasi");
            }
            return user;
        }

        public DbUser VHasMaintenance(DbUser user, IMaintenanceService _maintenanceService)
        {
            IList<Maintenance> list = _maintenanceService.GetObjectsByUserId(user.Id);
            if (list.Any())
            {
                user.Errors.Add("Maintenance", "Tidak boleh ada yang terasosiakan dengan user");
            }
            return user;
        }

        public DbUser VCreateObject(DbUser user, IUserService _userService)
        {
            VName(user, _userService);
            return user;
        }

        public DbUser VUpdateObject(DbUser user, IUserService _userService)
        {
            VName(user, _userService);
            return user;
        }

        public DbUser VDeleteObject(DbUser user, IMaintenanceService _maintenanceService)
        {
            VHasMaintenance(user, _maintenanceService);
            return user;
        }

        public bool ValidCreateObject(DbUser user, IUserService _userService)
        {
            VCreateObject(user, _userService);
            return isValid(user);
        }

        public bool ValidUpdateObject(DbUser user, IUserService _userService)
        {
            user.Errors.Clear();
            VUpdateObject(user, _userService);
            return isValid(user);
        }

        public bool ValidDeleteObject(DbUser user, IMaintenanceService _maintenanceService)
        {
            user.Errors.Clear();
            VDeleteObject(user, _maintenanceService);
            return isValid(user);
        }

        public bool isValid(DbUser obj)
        {
            bool isValid = !obj.Errors.Any();
            return isValid;
        }

        public string PrintError(DbUser obj)
        {
            string erroroutput = "";
            KeyValuePair<string, string> first = obj.Errors.ElementAt(0);
            erroroutput += first.Key + "," + first.Value;
            foreach (KeyValuePair<string, string> pair in obj.Errors.Skip(1))
            {
                erroroutput += Environment.NewLine;
                erroroutput += pair.Key + "," + pair.Value;
            }
            return erroroutput;
        }

    }
}
