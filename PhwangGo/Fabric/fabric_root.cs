using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhwangGo.Fabric
{
    public class FabricRootClass
    {
        public FabricAjaxParserClass FabricAjaxParserObject { get; }
        public FabricGoServiceClass FabricGoServiceObject { get; }

        public FabricRootClass ()
        {
            this.FabricGoServiceObject = new FabricGoServiceClass(this);
            this.FabricAjaxParserObject = new FabricAjaxParserClass(this);
            return;
        }
    }
}
