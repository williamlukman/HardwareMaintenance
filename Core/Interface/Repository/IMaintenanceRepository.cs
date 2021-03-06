﻿using Core.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interface.Repository
{
    public interface IMaintenanceRepository : IRepository<Maintenance>
    {
        IList<Maintenance> GetAll();
        IList<Maintenance> GetObjectsByItemId(int ItemId);
        IList<Maintenance> GetObjectsByCustomerId(int CustomerId);
        IList<Maintenance> GetObjectsByItemTypeId(int ItemTypeId);
        IList<Maintenance> GetObjectsByUserId(int UserId);
        Maintenance GetObjectById(int Id);
        Maintenance CreateObject(Maintenance maintenance);
        Maintenance UpdateObject(Maintenance maintenance);
        Maintenance SoftDeleteObject(Maintenance maintenance);
        Maintenance DiagnoseAndSolutionObject(Maintenance maintenance);
        Maintenance ConfirmObject(Maintenance maintenance);
        Maintenance UnconfirmObject(Maintenance maintenance);
        Maintenance CancelDiagnoseAndSolutionObject(Maintenance maintenace);
        bool DeleteObject(int Id);
        string SetObjectCode(Maintenance obj);
    }
}