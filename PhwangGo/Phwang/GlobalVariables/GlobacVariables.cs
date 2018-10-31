using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phwang.GlobalVariables
{
    public class GlobalVariableClass
    {
        static public FrontEnd.FrontEndRootClass frontEndRootObject { get; set; }
        static public Fabric.FabricRootClass fabricRootObject { get; set; }
        static public Theme.ThemeRootClass themeRootObject { get; set; }
        static public Engine.EngineRootClass engineRootObject { get; set; }

        public static void Initilization()
        {
            if (frontEndRootObject == null)
            {
                fabricRootObject = new Fabric.FabricRootClass();
                frontEndRootObject = new FrontEnd.FrontEndRootClass();
                themeRootObject = new Theme.ThemeRootClass();
                engineRootObject = new Engine.EngineRootClass();
            }
        }

        public static FrontEnd.FrontEndRootClass getGoRoot()
        {
            Initilization();
            return frontEndRootObject;
        }
    }
}
