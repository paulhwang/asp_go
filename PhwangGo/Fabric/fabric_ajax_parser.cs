using System;
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
    public class FabricAjaxParserClass
    {
        private object debug;

        private FabricRootClass RootObject { get; }
        private FabricAjaxResponseClass FabricAjaxResponseObject { get; }

        public FabricAjaxParserClass(FabricRootClass root_object_val)
        {
            this.RootObject = root_object_val;
            this.FabricAjaxResponseObject = new FabricAjaxResponseClass(this);
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
            string toDes = input_data_var;
            AjaxFabricRequestFormatClass ajax_fabric_request;
            using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(toDes)))
            {
                DataContractJsonSerializer deseralizer = new DataContractJsonSerializer(typeof(AjaxFabricRequestFormatClass));
                ajax_fabric_request = (AjaxFabricRequestFormatClass)deseralizer.ReadObject(ms);// //反序列化ReadObject
                Debug.WriteLine("input_data_var = " + input_data_var);
                Debug.WriteLine("command = " + ajax_fabric_request.command);
                Debug.WriteLine("packet_id = " + ajax_fabric_request.packet_id);
                Debug.WriteLine("data = " + ajax_fabric_request.data);
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
            Debug.WriteLine("input_data_var = " + input_data_var);
            SetupLinkRequestFormatClass format_data;
            using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(input_data_var)))
            {
                DataContractJsonSerializer deseralizer = new DataContractJsonSerializer(typeof(SetupLinkRequestFormatClass));
                format_data = (SetupLinkRequestFormatClass)deseralizer.ReadObject(ms);// //反序列化ReadObject
                Debug.WriteLine("my_name = " + format_data.my_name);
                Debug.WriteLine("password = " + format_data.password);
           }

            string response_data = this.FabricAjaxResponseObject.GenerateSetupLinkResponse(123, "phwang");
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
            Debug.WriteLine("input_data_var = " + input_data_var);
            GetLinkDataRequestFormat format_data;
            using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(input_data_var)))
            {
                DataContractJsonSerializer deseralizer = new DataContractJsonSerializer(typeof(GetLinkDataRequestFormat));
                format_data = (GetLinkDataRequestFormat)deseralizer.ReadObject(ms);// //反序列化ReadObject
                Debug.WriteLine("link_id = " + format_data.link_id);
            }

            string response_data = this.FabricAjaxResponseObject.GenerateGetLinkDataResponse(123, "phwang");
            return response_data;
        }
    }
}
