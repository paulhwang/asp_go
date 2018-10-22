using System;
using System.Collections.Generic;
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
