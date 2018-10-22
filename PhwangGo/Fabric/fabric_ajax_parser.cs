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
        private FabricRootClass rootObject { get; }
        private FabricJsonEncodeClass jsonEncodeObject { get; }

        public AjaxWebServiceClass (FabricRootClass root_object_val)
        {
            this.rootObject = root_object_val;
            this.jsonEncodeObject = new FabricJsonEncodeClass(this);
        }

        public string parseAjaxPacket (string input_data_var)
        {
            if (input_data_var == null)
            {
                return "null input data";
            }
 
            string output_data = this.jsonEncodeObject.EncodeLinkSetupResponse(123, "phwang");
            string response_data = this.jsonEncodeObject.EncodeResponse("setup_link", output_data);
            return response_data;
        }
    }
}
