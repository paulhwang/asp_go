using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phwang.GlobalVariables
{
    public class GlobalVariableClass
    {
        static public FrontEnd.FrontEndRootClass FrontEndRootObject { get; set; }
        static public Fabric.FabricRootClass FabricRootObject { get; set; }

        public static void Initilization()
        {
            if (FrontEndRootObject == null)
            {
                FabricRootObject = new Fabric.FabricRootClass();
                FrontEndRootObject = new FrontEnd.FrontEndRootClass();
            }
        }

        public static FrontEnd.FrontEndRootClass getGoRoot()
        {
            Initilization();
            return FrontEndRootObject;
        }
    }
}
