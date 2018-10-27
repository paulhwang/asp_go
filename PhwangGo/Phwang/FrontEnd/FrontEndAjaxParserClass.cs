﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Text;
using System.Diagnostics;

namespace Phwang.FrontEnd
{
    public class FrontEndAjaxParserClass
    {
        private string objectName = "FrontEndAjaxParserClass";

        private FrontEndRootClass frontEndRootObject { get; }
        private FrontEndAjaxResponseClass frontEndAjaxResponseObject { get; }

        public FrontEndAjaxParserClass(FrontEndRootClass root_object_val)
        {
            this.frontEndRootObject = root_object_val;
            this.frontEndAjaxResponseObject = new FrontEndAjaxResponseClass(this);
        }

        private FrontEndFabricClass frontEndFabricObject()
        {
            return this.frontEndRootObject.frontEndFabricObject;
        }

        public string ProcessAjaxInput(string input_data_var)
        {
            return this.ParseAjaxPacket(input_data_var);
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

        private string ParseAjaxPacket(string input_data_var)
        {
            this.debugIt(true, "ParseAjaxPacket", "input_data_var = " + input_data_var);
            this.frontEndFabricObject().transmitDataToFabric(input_data_var);
            string response_data = this.frontEndFabricObject().receiveDataFromFabric();
            this.debugIt(true, "ParseAjaxPacket", "response_data = " + response_data);
            return response_data;

            string toDes = input_data_var;
            AjaxFabricRequestFormatClass ajax_fabric_request;
            using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(toDes)))
            {
                DataContractJsonSerializer deseralizer = new DataContractJsonSerializer(typeof(AjaxFabricRequestFormatClass));
                ajax_fabric_request = (AjaxFabricRequestFormatClass)deseralizer.ReadObject(ms);
                this.debugIt(true, "ParseAjaxPacket", "command = " + ajax_fabric_request.command);
                this.debugIt(true, "ParseAjaxPacket", "data = " + ajax_fabric_request.data);
            }

            if (ajax_fabric_request.command == "setup_link")
            {
                return this.processSetupLinkRequest(ajax_fabric_request.data);
            }
            if (ajax_fabric_request.command == "get_link_data")
            {
                return this.processGetLinkDataRequest(ajax_fabric_request.data);
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

        private string processSetupLinkRequest (string input_data_var)
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

            this.frontEndFabricObject().transmitDataToFabric(format_data.my_name);
            //this.frontEndFabricObject().transmitDataToFabric(ajax_entry_object, "L" + ajax_entry_object.ajaxId() + format_data.my_name);

            string response_data = this.frontEndAjaxResponseObject.GenerateSetupLinkResponse(123, "phwang");
            return response_data;
        }

        [DataContract]
        public class GetLinkDataRequestFormat
        {
            [DataMember]
            public int link_id { get; set; }
        }

        private string processGetLinkDataRequest(string input_data_var)
        {
            this.debugIt(true, "processGetLinkDataRequest", "input_data_var = " + input_data_var);
            GetLinkDataRequestFormat format_data;
            using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(input_data_var)))
            {
                DataContractJsonSerializer deseralizer = new DataContractJsonSerializer(typeof(GetLinkDataRequestFormat));
                format_data = (GetLinkDataRequestFormat)deseralizer.ReadObject(ms);// //反序列化ReadObject
                this.debugIt(true, "processGetLinkDataRequest", "link_id = " + format_data.link_id);
            }

            string response_data = this.frontEndAjaxResponseObject.GenerateGetLinkDataResponse(123, "phwang");
            return response_data;
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