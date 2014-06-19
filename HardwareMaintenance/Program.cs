using Core.Constants;
using Core.DomainModel;
using Core.Interface.Service;
using Data.Context;
using Data.Repository;
using Service.Service;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validation.Validation;

namespace HardwareMaintenance
{
    public class Program
    {
        public static void Main(string[] args)
        
        {
            var db = new HardwareMaintenanceEntities();

            using (db)
            {
                ICustomerService customerService = new CustomerService(new CustomerRepository(), new CustomerValidator());
                IItemService itemService = new ItemService(new ItemRepository(), new ItemValidator());
                IItemTypeService itemTypeService = new ItemTypeService(new ItemTypeRepository(), new ItemTypeValidator());
                IUserService userService = new UserService(new UserRepository(), new UserValidator());
                IMaintenanceService maintenanceService = new MaintenanceService(new MaintenanceRepository(), new MaintenanceValidator());

                // Warning: this function will delete all data in the DB. Use with caution!!!
                db.DeleteAllTables();

                Customer customer = customerService.CreateObject("Hendy", "Jl. Panjang", "Andrew Papa Hendy", "081111111111", "hendy@orangkeren.com");
                DbUser user = userService.CreateObject("SSD DataEntry", "Inputin Barang Hendy yang rusak ke System donk");
                ItemType itemTypeLaptop = itemTypeService.CreateObject("Laptop", "Laptop milik perusahaan");
                ItemType itemTypePC = itemTypeService.CreateObject("PC", "PC milik perusahaan");
                Item item = new Item()
                {
                    CustomerId = customer.Id,
                    ItemTypeId = itemTypeLaptop.Id,
                    Description = "Laptop Lenovo D1900 2013",
                    ManufacturedAt = new DateTime(2013, 3,3),
                    WarrantyExpiryDate = new DateTime(2015, 3,3)
                };
                itemService.CreateObject(item, customerService, itemTypeService);
                Maintenance maintenanceHendy = new Maintenance()
                {
                    ItemId = item.Id,
                    CustomerId = customer.Id,
                    UserId = user.Id,
                    RequestDate = DateTime.Now,
                    Complaint = "Keyboard huruf a dan spacebar sudah tidak bekerja dengan baik",
                    Case = Constant.MaintenanceCase.Emergency
                };
                maintenanceHendy = maintenanceService.CreateObject(maintenanceHendy, itemService, itemTypeService, userService, customerService);

                maintenanceHendy = maintenanceService.DiagnoseAndSolutionObject(maintenanceHendy, "Waktunya untuk ganti ulang keyboard", Constant.DiagnosisCase.Replacement_Required, DateTime.Now, "Digantikan keyboard baru untuk Hendy", Constant.SolutionCase.Pending);

                maintenanceHendy = maintenanceService.ConfirmObject(maintenanceHendy);

                maintenanceHendy = maintenanceService.UnconfirmObject(maintenanceHendy);

                maintenanceHendy = maintenanceService.CancelDiagnoseAndSolutionObject(maintenanceHendy);

                maintenanceHendy = maintenanceService.SoftDeleteObject(maintenanceHendy);
                Console.WriteLine("Press any key to stop...");
                Console.ReadKey();
            }
        }
    }
}
