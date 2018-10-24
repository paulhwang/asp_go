using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhwangGo.FrontEnd
{
    public static class GlobalVariableClass
    {
        static public FabricRootClass fabricRootObject { get; set; }

        public static FabricRootClass getGoRoot()
        {
            if (fabricRootObject == null)
            {
                fabricRootObject = new FabricRootClass();
            }
            return fabricRootObject;
        }
    }
}
