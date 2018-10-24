using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phwang.Fabric
{
    public class FabricRootClass
    {
        private string ObjectName { get; }
        private PhwangUtils.PhwangApiClass PhwangApiObject { get; }

        public FabricRootClass()
        {
            this.ObjectName = "FabricRootClass";
            this.PhwangApiObject = new PhwangUtils.PhwangApiClass();
            this.debug(true, "FabricRootClass", "init");
        }

        private void debug(bool on_off_val, string str0_val, string str1_val)
        {
            if (on_off_val)
                this.logit(str0_val, str1_val);
        }

        private void logit(string str0_val, string str1_val)
        {
            this.PhwangApiObject.phwangLogit(this.ObjectName + "::" + str0_val, str1_val);
        }

        private void abend(string str0_val, string str1_val)
        {
            this.PhwangApiObject.phwangAbend(this.ObjectName + "::" + str0_val, str1_val);
        }
    }
}
