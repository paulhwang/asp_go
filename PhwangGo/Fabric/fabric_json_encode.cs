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
    public class FabricJsonEncodeClass
    {
        private AjaxWebServiceClass ajaxWebServiceObject { get; }

        public FabricJsonEncodeClass (AjaxWebServiceClass ajax_web_service_object_var)
        {
            this.ajaxWebServiceObject = ajax_web_service_object_var;
        }

        [DataContract]
        private class SetupLinkResponseFormat
        {
            [DataMember]
            public string my_name { get; set; }

            [DataMember]
            public int link_id { get; set; }
        }

        public string EncodeLinkSetupResponse(int link_id_var, string my_name_var)
        {
            SetupLinkResponseFormat stu = new SetupLinkResponseFormat { my_name = my_name_var, link_id = link_id_var };

            Debug.WriteLine("in AccountSignInReq()");
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(SetupLinkResponseFormat));
            MemoryStream msObj = new MemoryStream();
            //將序列化之後的Json格式資料寫入流中
            js.WriteObject(msObj, stu);
            msObj.Position = 0;
            //從0這個位置開始讀取流中的資料
            StreamReader sr = new StreamReader(msObj, Encoding.UTF8);
            string raw_output_data = sr.ReadToEnd();
            sr.Close();
            msObj.Close();
            Debug.WriteLine(raw_output_data);
            return raw_output_data;
        }

        [DataContract]
        private class ResponseFormat
        {
            [DataMember]
            public string command { get; set; }

            [DataMember]
            public string data { get; set; }
        }

        public string EncodeResponse(string command_var, string data_var)
        {
            ResponseFormat data1 = new ResponseFormat { command = command_var, data = data_var };

            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(ResponseFormat));
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
    }
}
