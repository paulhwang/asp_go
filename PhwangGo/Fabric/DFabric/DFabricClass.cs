using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Phwang.Fabric
{
    public class DFabricClass
    {
        private string ObjectName = "DFabricClass";

        private FabricRootClass FabricRootObject { get; }

        public DFabricClass(FabricRootClass fabric_root_class_val)
        {
            this.FabricRootObject = fabric_root_class_val;
            //this.startNetServer();
            this.debug(true, "UFabricClass", "init");
        }
        private void debug(bool on_off_val, string str0_val, string str1_val)
        {
            if (on_off_val)
                this.logit(str0_val, str1_val);
        }

        private void logit(string str0_val, string str1_val)
        {
            PhwangUtils.AbendClass.phwangLogit(this.ObjectName + "::" + str0_val, str1_val);
        }

        private void abend(string str0_val, string str1_val)
        {
            PhwangUtils.AbendClass.phwangAbend(this.ObjectName + "::" + str0_val, str1_val);
        }
    }
}
