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
            public string data { get; set; }

            [DataMember]
            public string my_name { get; set; }
        }

        private string ParseAjaxPacket(string input_data_var)
        {
            string toDes = input_data_var;
            using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(toDes)))
            {
                DataContractJsonSerializer deseralizer = new DataContractJsonSerializer(typeof(AjaxFabricRequestFormat));
                AjaxFabricRequestFormat model = (AjaxFabricRequestFormat)deseralizer.ReadObject(ms);// //反序列化ReadObject
                Debug.WriteLine("input_data_var = " + input_data_var);
                Debug.WriteLine("command = " + model.command);
                Debug.WriteLine("data = " + model.data);
                Debug.WriteLine("my_name = " + model.my_name);
            }

            return this.processSetupLinkRequest();
        }

        private string processSetupLinkRequest ()
        {
            string response_data = this.jsonEncodeObject.EncodeLinkSetupResponse(123, "phwang");
            return response_data;
        }
    }
}
