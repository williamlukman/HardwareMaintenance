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
    public class MaintenanceRepository : EfRepository<Maintenance>, IMaintenanceRepository
    {

        private HardwareMaintenanceEntities entities;
        public MaintenanceRepository()
        {
            entities = new HardwareMaintenanceEntities();
        }

        public IList<Maintenance> GetAll()
        {
            return FindAll().ToList();
        }

        public IList<Maintenance> GetObjectsByItemId(int ItemId)
        {
            return FindAll(x => x.ItemId == ItemId && !x.IsDeleted).ToList();
        }

        public IList<Maintenance> GetObjectsByCustomerId(int CustomerId)
        {
            return FindAll(x => x.CustomerId == CustomerId && !x.IsDeleted).ToList();
        }

        public IList<Maintenance> GetObjectsByItemTypeId(int ItemTypeId)
        {
            return FindAll(x => x.ItemTypeId == ItemTypeId && !x.IsDeleted).ToList();
        }

        public IList<Maintenance> GetObjectsByUserId(int UserId)
        {
            return FindAll(x => x.UserId == UserId && !x.IsDeleted).ToList();
        }

        public Maintenance GetObjectById(int Id)
        {
            Maintenance maintenance = Find(x => x.Id == Id && !x.IsDeleted);
            if (maintenance != null) { maintenance.Errors = new Dictionary<string, string>(); }
            return maintenance;
        }

        public Maintenance CreateObject(Maintenance maintenance)
        {
            maintenance.Code = SetObjectCode(maintenance);
            maintenance.IsDeleted = false;
            maintenance.CreatedAt = DateTime.Now;
            return Create(maintenance);
        }

        public Maintenance UpdateObject(Maintenance maintenance)
        {
            maintenance.UpdatedAt = DateTime.Now;
            Update(maintenance);
            return maintenance;
        }

        public Maintenance SoftDeleteObject(Maintenance maintenance)
        {
            maintenance.IsDeleted = true;
            maintenance.DeletedAt = DateTime.Now;
            Update(maintenance);
            return maintenance;
        }

        public Maintenance DiagnoseAndSolutionObject(Maintenance maintenance)
        {
            maintenance.IsDiagnosed = true;
            Update(maintenance);
            return maintenance;
        }

        public Maintenance ConfirmObject(Maintenance maintenance)
        {
            maintenance.IsFinished = true;
            Update(maintenance);
            return maintenance;
        }

        public Maintenance UnconfirmObject(Maintenance maintenance)
        {
            maintenance.IsFinished = false;
            Update(maintenance);
            return maintenance;
        }

        public Maintenance CancelDiagnoseAndSolutionObject(Maintenance maintenace)
        {
            maintenace.IsDiagnosed = false;
            Update(maintenace);
            return maintenace;
        }

        public bool DeleteObject(int Id)
        {
            Maintenance maintenance = Find(x => x.Id == Id);
            return (Delete(maintenance) == 1) ? true : false;
        }

        public string SetObjectCode(Maintenance obj)
        {
            //Code: Customer.Id/year_created_at/month_created_at/total_maintenance_in_that_year
            int totalobject = FindAll(x => x.CreatedAt.Year == DateTime.Now.Year).Count() + 1;
            string Code = obj.CustomerId + "/" + DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + totalobject;
            return Code;
        }
    }
}