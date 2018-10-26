/*
 ******************************************************************************
 *                                       
 *  Copyright (c) 2018 phwang. All rights reserved.
 *
 ******************************************************************************
 */

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
        private string objectName = "DFabricClass";

        private FabricRootClass fabricRootObject { get; }
        private PhwangUtils.BinderClass binderObject { get; }
        PhwangUtils.TcpServerClass TpServerObject { get; set; }

        public DFabricClass(FabricRootClass fabric_root_class_val)
        {
            this.debugIt(true, "DFabricClass", "init start");
            this.fabricRootObject = fabric_root_class_val;
            //this.startNetServer();
            this.binderObject = new PhwangUtils.BinderClass(this.objectName);
            this.binderObject.BindAsTcpServer(PortProtocolClass.LINK_MGR_PROTOCOL_TRANSPORT_PORT_NUMBER);
            this.debugIt(true, "DFabricClass", "init done");
        }

        void startNetServer()
        {
            this.TpServerObject = PhwangUtils.TcpApiClass.MallocTcpServer(this, PortProtocolClass.LINK_MGR_PROTOCOL_TRANSPORT_PORT_NUMBER, dFabricTpServerAcceptFunction /*, this, dFabricTpReceiveDataFunction, this*/, this.objectName);
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

        void dFabricTpReceiveDataFunction(object tp_transfer_object_val, object d_fabric_object_val, object data_val)
        {
            /*
            if (*((char*)data_val) != WEB_FABRIC_PROTOCOL_COMMAND_IS_GET_LINK_DATA)
            {
                printf("Golbal::dFabricTpReceiveDataFunction index=%d)))))))))))))))))))))))))))))))))))))))))\n", ((TpTransferClass*)tp_transfer_object_val)->index());
                phwangLogit("Golbal::dFabricTpReceiveDataFunction", (char*)data_val);
            }
            */
           //((DFabricClass*)d_fabric_object_val)->exportedparseFunction(tp_transfer_object_val, (char*)data_val);
            //phwangFree(data_val, "dFabricTpReceiveDataFunction");
        }

        private void debugIt(bool on_off_val, string str0_val, string str1_val)
        {
            if (on_off_val)
                this.logitIt(str0_val, str1_val);
        }

        private void logitIt(string str0_val, string str1_val)
        {
            PhwangUtils.AbendClass.phwangLogit(this.objectName + "." + str0_val + "()", str1_val);
        }

        private void abendIt(string str0_val, string str1_val)
        {
            PhwangUtils.AbendClass.phwangAbend(this.objectName + "." + str0_val + "()", str1_val);
        }
    }
}
