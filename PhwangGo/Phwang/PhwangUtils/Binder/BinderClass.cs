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
        private string ObjectName = "BinderClass";

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
            return true;
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
            PhwangUtils.AbendClass.phwangLogit(this.ObjectName + "(" +this.ownerObject + ")." + str0_val + "()", str1_val);
        }

        private void abendIt(string str0_val, string str1_val)
        {
            PhwangUtils.AbendClass.phwangAbend(this.ObjectName + "." + str0_val +"()", str1_val);
        }
    }
}
