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
    public class AjaxWebServiceClass
    {
        FabricRootClass rootObject { get; }

        public AjaxWebServiceClass (FabricRootClass root_object_val)
        {
            //this.rootObject = root_object_val;
        }

        public string parseAjaxPacket (string input_data_var)
        {
            if (input_data_var == null)
            {
                return "null input data";
            }
            Fabric.FabricRootClass go_root = Fabric.GlobalVariableClass.getGoRoot();
            if (go_root == null)
            {
                return "junk";
            }
            string input_data = null;
            string raw_output_data = null;
            string output_data = null;
            SetupLinkResponse stu = new SetupLinkResponse { my_name = "paul9", link_id = 123 };

            Debug.WriteLine("in AccountSignInReq()");
            {
                input_data = input_data_var;

                DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(SetupLinkResponse));
                MemoryStream msObj = new MemoryStream();
                //將序列化之後的Json格式資料寫入流中
                js.WriteObject(msObj, stu);
                msObj.Position = 0;
                //從0這個位置開始讀取流中的資料
                StreamReader sr = new StreamReader(msObj, Encoding.UTF8);
                raw_output_data = sr.ReadToEnd();
                sr.Close();
                msObj.Close();
            }

            Debug.WriteLine(raw_output_data);

            output_data = AddJsonOuter("setup_link", raw_output_data);
            return output_data;
        }

        [DataContract]
        public class SetupLinkResponse
        {
            [DataMember]
            public string my_name { get; set; }

            [DataMember]
            public int link_id { get; set; }
        }

        [DataContract]
        public class JsonOuter
        {
            [DataMember]
            public string command { get; set; }

            [DataMember]
            public string data { get; set; }
        }

        public string AddJsonOuter(string command_var, string data_var)
        {
            JsonOuter data1 = new JsonOuter { command = command_var, data = data_var };

            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(JsonOuter));
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
