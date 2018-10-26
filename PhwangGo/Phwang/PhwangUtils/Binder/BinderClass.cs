﻿/*
 ******************************************************************************
 *                                       
 *  Copyright (c) 2018 phwang. All rights reserved.
 *
 ******************************************************************************
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace Phwang.PhwangUtils
{
    public class BinderClass
    {
        private string objectName = "BinderClass";

        private string ownerObject { get; }

        //void* theReceiveObject;
        public NetworkStream netStream { get; }
        Thread receiveThread { get; }
        Thread transmitThread { get; }

        //Thread theReceiveThread2;
        //void* theTransmitQueue;
        //void* theReceiveQueue;


        public BinderClass(string owner_object_var)
        {
            this.ownerObject = owner_object_var;

            this.receiveThread = new Thread(this.receiveThreadFunc);
            this.receiveThread.Start();

            this.transmitThread = new Thread(this.transmitThreadFunc);
            this.transmitThread.Start();
        }

        public bool BindAsTcpClient(string ip_addr_var, short port_var)
        {
            TcpClient client = new TcpClient(ip_addr_var, port_var);
            this.debugIt(true, "BindAsTcpClient", "connected!");
            NetworkStream stream = client.GetStream();
            //Utils.DebugClass.DebugIt("TcpClient", "end");

            PhwangUtils.TcpServerClass.TcpTransmitData(stream, "hello there****************");
            return true;
        }

        public bool BindAsTcpServer(short port_var)
        {
            PhwangUtils.TcpApiClass.MallocTcpServer(this, FabricFrontEnd.FabricFrontEndProtocolClass.LINK_MGR_PROTOCOL_TRANSPORT_PORT_NUMBER, binderTcpServerAcceptFunc /*, this, binderTcpReceiveDataFunc, this*/, this.objectName);
            return true;
        }

        private void binderTcpServerAcceptFunc(object d_fabric_object_val, PhwangUtils.TcpTransferClass tp_transfer_object_val)
        {
            this.debugIt(true, "binderTcpServerAcceptFunc", "accepted!");

            while (true)
            {
                PhwangUtils.TcpServerClass.TcpReceiveData___(tp_transfer_object_val.theStream);
                Thread.Sleep(1000);
            }
            //((DFabricClass*)d_fabric_object_val)->exportedNetAcceptFunction(tp_transfer_object_val);
        }

        private void binderTcpReceiveDataFunc(object tp_transfer_object_val, object d_fabric_object_val, object data_val)
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

        private void receiveThreadFunc()
        {
            this.debugIt(true, "receiveThreadFunc", "start");
            while (true)
            {

            }
        }

        private void transmitThreadFunc()
        {
            this.debugIt(true, "transmitThreadFunc", "start");
            while (true)
            {

            }
        }

        public void TransmitRawData(string data_var)
        {

        }

        public string ReceiveRawData()
        {
            return null;
        }

        public void TransmitData(string data_var)
        {
            this.TransmitRawData(data_var);
        }

        public string ReceivData()
        {
            return this.ReceiveRawData();
        }

        private void debugIt(bool on_off_val, string str0_val, string str1_val)
        {
            if (on_off_val)
                this.logitIt(str0_val, str1_val);
        }

        private void logitIt(string str0_val, string str1_val)
        {
            PhwangUtils.AbendClass.phwangLogit(this.objectName + "(" +this.ownerObject + ")." + str0_val + "()", str1_val);
        }

        private void abendIt(string str0_val, string str1_val)
        {
            PhwangUtils.AbendClass.phwangAbend(this.objectName + "." + str0_val +"()", str1_val);
        }
    }
}
