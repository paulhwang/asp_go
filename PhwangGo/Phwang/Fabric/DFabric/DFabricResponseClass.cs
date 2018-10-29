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
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace Phwang.Fabric
{
    public class DFabricResponseClass
    {
        private string objectName = "DFabricResponseClass";

        private DFabricParserClass dFabricResponseObject { get; }

        public DFabricResponseClass(DFabricParserClass dfabric_response_object_val)
        {
            this.dFabricResponseObject = dfabric_response_object_val;
        }

        [DataContract]
        private class ResponseFormatClass
        {
            [DataMember]
            public string command { get; set; }

            [DataMember]
            public string data { get; set; }
        }

        private string EncodeResponse(string command_var, string data_var)
        {
            ResponseFormatClass data1 = new ResponseFormatClass { command = command_var, data = data_var };

            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(ResponseFormatClass));
            MemoryStream msObj = new MemoryStream();
            //將序列化之後的Json格式資料寫入流中
            js.WriteObject(msObj, data1);
            msObj.Position = 0;
            //從0這個位置開始讀取流中的資料
            StreamReader sr = new StreamReader(msObj, Encoding.UTF8);
            string data = sr.ReadToEnd();
            sr.Close();
            msObj.Close();
            this.debugIt(true, "EncodeResponse", "data = " + data);
            return data;
        }

        [DataContract]
        private class SetupLinkResponseFormatClass
        {
            [DataMember]
            public string my_name { get; set; }

            [DataMember]
            public int link_id { get; set; }
        }

        public string GenerateSetupLinkResponse(int link_id_var, string my_name_var)
        {
            SetupLinkResponseFormatClass raw_data = new SetupLinkResponseFormatClass { my_name = my_name_var, link_id = link_id_var };

            this.debugIt(true, "GenerateSetupLinkResponse", "");
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(SetupLinkResponseFormatClass));
            MemoryStream msObj = new MemoryStream();

            js.WriteObject(msObj, raw_data);
            msObj.Position = 0;

            StreamReader sr = new StreamReader(msObj, Encoding.UTF8);
            string data = sr.ReadToEnd();
            sr.Close();
            msObj.Close();

            this.debugIt(true, "GenerateSetupLinkResponse", "data = " + data);
            string response_data = this.EncodeResponse("setup_link", data);
            return response_data;
        }

        [DataContract]
        private class GetLinkDataResponseFormatClass
        {
            [DataMember]
            public string link_id { get; set; }

            [DataMember]
            public string interval { get; set; }

            [DataMember]
            public string data { get; set; }

            [DataMember]
            public string pending_session_setup { get; set; }
        }

        public string GenerateGetLinkDataResponse(string link_id_str_var, string my_name_var)
        {
            GetLinkDataResponseFormatClass raw_data = new GetLinkDataResponseFormatClass { link_id = link_id_str_var, interval = "1000", data = null, pending_session_setup = null };

            this.debugIt(true, "EncodeLinkSetupResponse", "");
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(GetLinkDataResponseFormatClass));
            MemoryStream msObj = new MemoryStream();

            js.WriteObject(msObj, raw_data);
            msObj.Position = 0;

            StreamReader sr = new StreamReader(msObj, Encoding.UTF8);
            string data = sr.ReadToEnd();
            sr.Close();
            msObj.Close();
            this.debugIt(true, "EncodeLinkSetupResponse", data);

            string response_data = this.EncodeResponse("get_link_data", data);
            return response_data;
        }

        [DataContract]
        private class SetupSessionResponseFormatClass
        {
            [DataMember]
            public string link_id { get; set; }

            [DataMember]
            public string session_id { get; set; }
        }

        public string GenerateSetupSessionResponse(string link_id_str_val, string session_id_str_val)
        {
            SetupSessionResponseFormatClass raw_data = new SetupSessionResponseFormatClass { link_id = link_id_str_val, session_id = session_id_str_val };

            this.debugIt(true, "EncodeLinkSetupResponse", "");
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(SetupSessionResponseFormatClass));
            MemoryStream msObj = new MemoryStream();

            js.WriteObject(msObj, raw_data);
            msObj.Position = 0;

            StreamReader sr = new StreamReader(msObj, Encoding.UTF8);
            string data = sr.ReadToEnd();
            sr.Close();
            msObj.Close();
            this.debugIt(true, "EncodeLinkSetupResponse", data);

            string response_data = this.EncodeResponse("setup_session", data);
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
