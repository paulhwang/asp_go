/*
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

        private void receiveThreadFunc()
        {
            this.debugIt(true, "receiveThreadFunc", "start by: " + this.ownerObject);
            while (true)
            {

            }
        }

        private void transmitThreadFunc()
        {
            this.debugIt(true, "transmitThreadFunc", "start by: " + this.ownerObject);
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
            PhwangUtils.AbendClass.phwangLogit(this.ObjectName + "." + str0_val, str1_val);
        }

        private void abendIt(string str0_val, string str1_val)
        {
            PhwangUtils.AbendClass.phwangAbend(this.ObjectName + "." + str0_val, str1_val);
        }
    }
}
