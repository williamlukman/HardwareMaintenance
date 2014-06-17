using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Constants
{
    public class Constant
    {
        public class MaintenanceCase
        {
            public static int Scheduled = 1;
            public static int Emergency = 2;
        }

        public class DiagnosisCase
        {
            public static int All_Ok = 1;
            public static int Fix_Required = 2;
            public static int Replacement_Required = 3;
        }

        public class SolutionCase
        {
            public static int Normal = 1;
            public static int Pending = 2;
            public static int Solved = 3;
        }
    }
}
