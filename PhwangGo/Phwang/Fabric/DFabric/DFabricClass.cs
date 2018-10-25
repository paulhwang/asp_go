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
        PhwangUtils.TcpServerClass TpServerObject { get; set; }

        public DFabricClass(FabricRootClass fabric_root_class_val)
        {
            this.FabricRootObject = fabric_root_class_val;
            this.startNetServer();
            this.debugIt(true, "UFabricClass", "init");
        }

        void startNetServer()
        {
            this.TpServerObject = PhwangUtils.TcpApiClass.MallocTcpServer(this, PortProtocolClass.LINK_MGR_PROTOCOL_TRANSPORT_PORT_NUMBER/*, dFabricTpServerAcceptFunction, this, dFabricTpReceiveDataFunction, this*/, this.ObjectName);
        }

        private void debugIt(bool on_off_val, string str0_val, string str1_val)
        {
            if (on_off_val)
                this.logitIt(str0_val, str1_val);
        }

        private void logitIt(string str0_val, string str1_val)
        {
            PhwangUtils.AbendClass.phwangLogit(this.ObjectName + "::" + str0_val, str1_val);
        }

        private void abendIt(string str0_val, string str1_val)
        {
            PhwangUtils.AbendClass.phwangAbend(this.ObjectName + "::" + str0_val, str1_val);
        }
    }
}
