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
using System.Threading.Tasks;

namespace Phwang.PhwangUtils
{
    public class BinderClass
    {
        private string ObjectName = "BinderClass";

        //void* theReceiveObject;
        public NetworkStream theStream { get; }
        int theIndex;

        //pthread_t theReceiveThread;
        //pthread_t theReceiveThread2;
        //pthread_t theTransmitThread;
        //void* theTransmitQueue;
        //void* theReceiveQueue;


        public BinderClass()
        {
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
