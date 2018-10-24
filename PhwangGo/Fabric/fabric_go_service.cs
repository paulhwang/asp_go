using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhwangGo.Fabric
{

    public class FabricGoServiceClass
    {
        private FabricRootClass FabricRootObject { get; }

        public FabricGoServiceClass(FabricRootClass root_object_val)
        {
            this.FabricRootObject = root_object_val;
        }

    }
}
