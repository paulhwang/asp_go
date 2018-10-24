﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Text;
using System.Diagnostics;

namespace PhwangGo.Fabric
{
    public class AjaxWebServiceClass
    {
        private object debug;

        private FabricRootClass rootObject { get; }
        private FabricJsonEncodeClass jsonEncodeObject { get; }

        public AjaxWebServiceClass (FabricRootClass root_object_val)
        {
            this.rootObject = root_object_val;
            this.jsonEncodeObject = new FabricJsonEncodeClass(this);
        }

        public string ProcessAjaxInput(string input_data_var)
        {
            return this.ParseAjaxPacket(input_data_var);
        }

        [DataContract]
        public class AjaxFabricRequestFormat
        {
            [DataMember]
            public string command { get; set; }

            [DataMember]
            public int packet_id { get; set; }

            [DataMember]
            public string data { get; set; }
        }

        private string ParseAjaxPacket(string input_data_var)
        {
            string toDes = input_data_var;
            AjaxFabricRequestFormat ajax_fabric_request;
            using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(toDes)))
            {
                DataContractJsonSerializer deseralizer = new DataContractJsonSerializer(typeof(AjaxFabricRequestFormat));
                ajax_fabric_request = (AjaxFabricRequestFormat)deseralizer.ReadObject(ms);// //反序列化ReadObject
                Debug.WriteLine("input_data_var = " + input_data_var);
                Debug.WriteLine("command = " + ajax_fabric_request.command);
                Debug.WriteLine("packet_id = " + ajax_fabric_request.packet_id);
                Debug.WriteLine("data = " + ajax_fabric_request.data);
            }

            if (ajax_fabric_request.command == "setup_link")
            {
                return this.processSetupLinkRequest(ajax_fabric_request.data);
            }
            return "command " + ajax_fabric_request.command + " not supported";
        }

        [DataContract]
        public class SetupLinkRequestFormat
        {
            [DataMember]
            public string my_name { get; set; }

            [DataMember]
            public string password { get; set; }
        }

        private string processSetupLinkRequest (string input_data_var)
        {
            Debug.WriteLine("input_data_var = " + input_data_var);
            SetupLinkRequestFormat setup_link_request;
            string toDes = input_data_var;
            using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(toDes)))
            {
                DataContractJsonSerializer deseralizer = new DataContractJsonSerializer(typeof(SetupLinkRequestFormat));
                setup_link_request = (SetupLinkRequestFormat)deseralizer.ReadObject(ms);// //反序列化ReadObject
                Debug.WriteLine("my_name = " + setup_link_request.my_name);
                Debug.WriteLine("password = " + setup_link_request.password);
           }
            string response_data = this.jsonEncodeObject.EncodeLinkSetupResponse(123, "phwang");
            return response_data;
        }
    }
}
