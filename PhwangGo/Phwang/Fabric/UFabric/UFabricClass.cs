using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phwang.Fabric
{
    public class UFabricClass
    {
        private string ObjectName = "UFabricClass";

        private FabricRootClass FabricRootObject { get; }
        //void* theTpServerObject;
        //void* theTpTransferObject;

        public UFabricClass(FabricRootClass fabric_root_class_val)
        {
            this.FabricRootObject = fabric_root_class_val;
            this.StartNetServer();
            this.debug(true, "UFabricClass", "init");
        }

        void StartNetServer()
        {
            //this.TpServerObject = phwangMallocTpServer(this, GROUP_ROOM_PROTOCOL_TRANSPORT_PORT_NUMBER, uFabricTpServerAcceptFunction, this, uFabricTpReceiveDataFunction, this, this->objectName());
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
