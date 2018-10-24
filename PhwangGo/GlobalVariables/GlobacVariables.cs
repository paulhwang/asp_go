using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhwangGo.GlobalVariables
{
    public static class GlobalVariableClass
    {
        static public FrontEnd.FrontRootClass FrontEndRootObject { get; set; }
        static public Fabric.FabricRootClass FabricRootObject { get; set; }

        public static FrontEnd.FrontRootClass getGoRoot()
        {
            if (FrontEndRootObject == null)
            {
                FrontEndRootObject = new FrontEnd.FrontRootClass();
            }
            if (FabricRootObject == null)
            {
                FabricRootObject = new Fabric.FabricRootClass();
            }
            return FrontEndRootObject;
        }
    }
}
