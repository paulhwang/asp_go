﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace Phwang.PhwangUtils
{
    public class TcpServerClass
    {
        private string objectName = "TcpServerClass";

        private object callerObject { get; }
        private string ipAddr { get; }
        private short tcpPort { get; }
        private string theWho { get; }
        private Thread serverThread { get; }

        public delegate void TcpAcceptDelegate(object a, object b);

        TcpAcceptDelegate acceptCallbackFunc;
        //void (* theAcceptCallbackFunc) (void*, void*);
        //void (* theReceiveCallbackFunc) (void*, void*, void*);
        //void* theAcceptCallbackParameter;
        //  void* theReceiveCallbackParameter;
        int tpTransferObjectIndex { get; }

        public TcpServerClass(
                    Object caller_object_val,
                    short port_val,
                    TcpAcceptDelegate accept_callback_func_val,
                    /*,
                    void (* accept_callback_func_val) (void*, void*),
                    void* accept_callback_parameter_val,
                    void (* receive_callback_func_val) (void*, void*, void*),
                    void* receive_callback_parameter_val*/
                    string who_val)

        {
            this.callerObject = caller_object_val;
            this.ipAddr = "127.0.0.1";
            this.tcpPort = port_val;
            this.acceptCallbackFunc = accept_callback_func_val;
            //this->theAcceptCallbackFunc = accept_callback_func_val;
            //this->theReceiveCallbackFunc = receive_callback_func_val;
            //this->theAcceptCallbackParameter = accept_callback_parameter_val;
            //this->theReceiveCallbackParameter = receive_callback_parameter_val;
            this.theWho = who_val;
            this.tpTransferObjectIndex = 1;

            this.debugIt(true, who_val, "TpServerClass");
            //this.debug(true, "TpServerClass", "init");
        }
 
        public void StartServerThread()
        {
            this.debugIt(true, "startServerThread", "invoker");

            Thread server_thread = new Thread(tcpServerThreadFunction);
            if (server_thread == null)
            {
                this.abendIt("StartServerThread", "null serverThread");
                return;
            }
            server_thread.Start(new IpAddrPort(this.ipAddr, this.tcpPort));
        }

        private void tcpServerThreadFunction(object tp_server_object_val)
        {
            AbendClass.phwangLogit( "tcpServerThreadFunction", "start");

            TcpListener listener = new TcpListener(System.Net.IPAddress.Parse(this.ipAddr), this.tcpPort);
            listener.Start();
            this.debugIt(true, "tcpServerThreadFunction", "after listener.Start()");

            TcpClient client = listener.AcceptTcpClient();
            this.debugIt(true, "tcpServerThreadFunction", "after AcceptTcpClient*******************");

            NetworkStream stream = client.GetStream();
            this.debugIt(true, "tcpServerThreadFunction", "after GetStream");

            this.acceptCallbackFunc(null, null);

            while (true)
            {
                this.TcpReceiveData___(stream);
                Thread.Sleep(1000);
            }
                //int path_id = this.IpcPath().AllocPath(stream);
        }

        public static void TcpTransmitData(NetworkStream stream_var, string data_var)
        {
            BinaryWriter writer = new BinaryWriter(stream_var);
            writer.Write(data_var);
            writer.Flush();
        }

        public string TcpReceiveData___(NetworkStream stream_var)
        {
            BinaryReader reader = new BinaryReader(stream_var);

            try
            {
                string data = reader.ReadString();
                this.debugIt(true, "TCpReceiveData: **************data=", data);
                return data;
            }
            catch (Exception ex)
            {
                this.debugIt(true, "TCpReceiveData", "exception");
                return null;
            }
        }

        private void debugIt(bool on_off_val, string str0_val, string str1_val)
        {
            if (on_off_val)
                this.logitIt(str0_val, str1_val);
        }

        private void logitIt(string str0_val, string str1_val)
        {
            PhwangUtils.AbendClass.phwangLogit(this.objectName + "::" + str0_val, str1_val);
        }

        private void abendIt(string str0_val, string str1_val)
        {
            PhwangUtils.AbendClass.phwangAbend(this.objectName + "::" + str0_val, str1_val);
        }
    }
}
