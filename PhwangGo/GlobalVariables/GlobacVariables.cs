using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhwangGo.FrontEnd
{
    public static class GlobalVariableClass
    {
        static public FrontRootClass fabricRootObject { get; set; }

        public static FrontRootClass getGoRoot()
        {
            if (fabricRootObject == null)
            {
                fabricRootObject = new FrontRootClass();
            }
            return fabricRootObject;
        }
    }
}
