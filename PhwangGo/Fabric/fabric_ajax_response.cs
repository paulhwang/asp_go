using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace PhwangGo.Fabric
{
    public class FabricAjaxResponseClass
    {
        private FabricAjaxParserClass FabricAjaxParserObject { get; }

        public FabricAjaxResponseClass(FabricAjaxParserClass ajax_web_service_object_var)
        {
            this.FabricAjaxParserObject = ajax_web_service_object_var;
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

            Debug.WriteLine("in EncodeLinkSetupResponse()");
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(SetupLinkResponseFormatClass));
            MemoryStream msObj = new MemoryStream();

            js.WriteObject(msObj, raw_data);
            msObj.Position = 0;

           StreamReader sr = new StreamReader(msObj, Encoding.UTF8);
            string data = sr.ReadToEnd();
            sr.Close();
            msObj.Close();
            Debug.WriteLine(data);

            string response_data = this.EncodeResponse("setup_link", data);
            return response_data;
        }

        [DataContract]
        private class GetLinkDataResponseFormatClass
        {
            [DataMember]
            public string my_name { get; set; }

            [DataMember]
            public int link_id { get; set; }
        }

        public string GenerateGetLinkDataResponse(int link_id_var, string my_name_var)
        {
            GetLinkDataResponseFormatClass raw_data = new GetLinkDataResponseFormatClass { my_name = my_name_var, link_id = link_id_var };

            Debug.WriteLine("in EncodeLinkSetupResponse()");
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(GetLinkDataResponseFormatClass));
            MemoryStream msObj = new MemoryStream();

            js.WriteObject(msObj, raw_data);
            msObj.Position = 0;

            StreamReader sr = new StreamReader(msObj, Encoding.UTF8);
            string data = sr.ReadToEnd();
            sr.Close();
            msObj.Close();
            Debug.WriteLine(data);

            string response_data = this.EncodeResponse("get_link_data", data);
            return response_data;
        }
    }
}
