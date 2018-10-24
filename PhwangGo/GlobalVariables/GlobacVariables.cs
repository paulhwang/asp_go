using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhwangGo.GlobalVariables
{
    public static class GlobalVariableClass
    {
        static public FrontEnd.FrontEndRootClass FrontEndRootObject { get; set; }
        static public Fabric.FabricRootClass FabricRootObject { get; set; }

        public static FrontEnd.FrontEndRootClass getGoRoot()
        {
            if (FrontEndRootObject == null)
            {
                FabricRootObject = new Fabric.FabricRootClass();
                FrontEndRootObject = new FrontEnd.FrontEndRootClass();
            }
            return FrontEndRootObject;
        }
    }
}
