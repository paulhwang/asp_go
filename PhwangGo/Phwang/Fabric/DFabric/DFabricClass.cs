using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Threading;
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
            this.TpServerObject = PhwangUtils.TcpApiClass.MallocTcpServer(this, PortProtocolClass.LINK_MGR_PROTOCOL_TRANSPORT_PORT_NUMBER, dFabricTpServerAcceptFunction /*, this, dFabricTpReceiveDataFunction, this*/, this.ObjectName);
        }
        void dFabricTpServerAcceptFunction(object d_fabric_object_val, PhwangUtils.TcpTransferClass tp_transfer_object_val)
        {
            this.debugIt(true, "dFabricTpServerAcceptFunction", "*****************************************");

            while (true)
            {
                PhwangUtils.TcpServerClass.TcpReceiveData___(tp_transfer_object_val.theStream);
                Thread.Sleep(1000);
            }
            //((DFabricClass*)d_fabric_object_val)->exportedNetAcceptFunction(tp_transfer_object_val);
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
