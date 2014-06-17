using Data.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareMaintenance
{
    public class Program
    {
        static void Main(string[] args)
        
        {
            var db = new HardwareMaintenanceEntities();

            using (db)
            {
                Program p = new Program();
                // Warning: this function will delete all data in the DB. Use with caution!!!
                db.DeleteAllTables();
                Console.WriteLine("Press any key to stop...");
                Console.ReadKey();
            }
        }
    }
}
