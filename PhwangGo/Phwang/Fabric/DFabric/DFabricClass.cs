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
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace Phwang.Fabric
{
    public class DFabricClass
    {
        private string objectName = "DFabricClass";

        private FabricRootClass fabricRootObject { get; }
        private DFabricParserClass dFabricParserObject { get; }
        private DFabricResponseClass dFabricResponseObject { get; }
        private PhwangUtils.BinderClass binderObject { get; }
        private Thread receiveThread { get; set; }

        public DFabricClass(FabricRootClass fabric_root_class_val)
        {
            this.debugIt(true, "DFabricClass", "init start");
            this.fabricRootObject = fabric_root_class_val;
            this.dFabricParserObject = new DFabricParserClass(this);
            this.dFabricResponseObject = new DFabricResponseClass(this);
            this.binderObject = new PhwangUtils.BinderClass(this.objectName);
            this.binderObject.BindAsTcpServer(FabricFrontEnd.FabricFrontEndProtocolClass.LINK_MGR_PROTOCOL_TRANSPORT_PORT_NUMBER);

            this.receiveThread = new Thread(this.receiveThreadFunc);
            this.receiveThread.Start();

            this.debugIt(true, "DFabricClass", "init done");
        }

        private void receiveThreadFunc()
        {
            this.debugIt(true, "receiveThreadFunc", "start");

            string data;
            while (true)
            {
                data = this.binderObject.ReceiveData();
                if (data == null)
                {
                    this.abendIt("receiveThreadFunc", "null data");
                    continue;
                }
                this.debugIt(true, "receiveThreadFunc", "data = " + data);
                this.parseInputPacket(data);

            }
        }


        [DataContract]
        public class AjaxFabricRequestFormatClass
        {
            [DataMember]
            public string command { get; set; }

            [DataMember]
            public int packet_id { get; set; }

            [DataMember]
            public string data { get; set; }
        }

        private string parseInputPacket(string input_data_var)
        {
            string toDes = input_data_var;
            AjaxFabricRequestFormatClass ajax_fabric_request;
            using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(toDes)))
            {
                DataContractJsonSerializer deseralizer = new DataContractJsonSerializer(typeof(AjaxFabricRequestFormatClass));
                ajax_fabric_request = (AjaxFabricRequestFormatClass)deseralizer.ReadObject(ms);
                this.debugIt(true, "ParseAjaxPacket", "input_data_var = " + input_data_var);
                this.debugIt(true, "ParseAjaxPacket", "command = " + ajax_fabric_request.command);
                this.debugIt(true, "ParseAjaxPacket", "data = " + ajax_fabric_request.data);
            }

            if (ajax_fabric_request.command == "setup_link")
            {
                this.processSetupLinkRequest(ajax_fabric_request.data);
            }
            if (ajax_fabric_request.command == "get_link_data")
            {
                this.processGetLinkDataRequest(ajax_fabric_request.data);
            }
            return "command " + ajax_fabric_request.command + " not supported";
        }

        [DataContract]
        public class SetupLinkRequestFormatClass
        {
            [DataMember]
            public string my_name { get; set; }

            [DataMember]
            public string password { get; set; }
        }

        private void processSetupLinkRequest(string input_data_var)
        {
            this.debugIt(true, "processSetupLinkRequest", "input_data_var = " + input_data_var);
            SetupLinkRequestFormatClass format_data;
            using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(input_data_var)))
            {
                DataContractJsonSerializer deseralizer = new DataContractJsonSerializer(typeof(SetupLinkRequestFormatClass));
                format_data = (SetupLinkRequestFormatClass)deseralizer.ReadObject(ms);// //反序列化ReadObject
                this.debugIt(true, "processSetupLinkRequest", "my_name = " + format_data.my_name);
                this.debugIt(true, "processSetupLinkRequest", "password = " + format_data.password);
            }

            int link_id = 100;

            string response_data = this.dFabricResponseObject.GenerateSetupLinkResponse(link_id, "phwang");
            this.binderObject.TransmitData(response_data);
        }

        [DataContract]
        public class GetLinkDataRequestFormat
        {
            [DataMember]
            public int link_id { get; set; }
        }

        private void processGetLinkDataRequest(string input_data_var)
        {
            this.debugIt(true, "processGetLinkDataRequest", "input_data_var = " + input_data_var);
            GetLinkDataRequestFormat format_data;
            using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(input_data_var)))
            {
                DataContractJsonSerializer deseralizer = new DataContractJsonSerializer(typeof(GetLinkDataRequestFormat));
                format_data = (GetLinkDataRequestFormat)deseralizer.ReadObject(ms);// //反序列化ReadObject
                this.debugIt(true, "processGetLinkDataRequest", "link_id = " + format_data.link_id);
            }

            //string response_data = this.frontEndAjaxResponseObject.GenerateGetLinkDataResponse(123, "phwang");
            //return response_data;
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
