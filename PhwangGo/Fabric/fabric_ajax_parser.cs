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

        public string ProcessAjaxInput(string input_data_var)
        {
            return this.ParseAjaxPacket(input_data_var);
        }

        private string ParseAjaxPacket(string input_data_var)
        {
            return this.processSetupLinkRequest();
        }

        private string processSetupLinkRequest ()
        {
            string response_data = this.jsonEncodeObject.EncodeLinkSetupResponse(123, "phwang");
            return response_data;
        }
    }
}
