﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhwangGo.Fabric
{
    public class FabricRootClass
    {
        public AjaxWebServiceClass ajaxFabricServiceObject { get; }

        public FabricRootClass ()
        {
            this.ajaxFabricServiceObject = new AjaxWebServiceClass(this);
            return;
        }
    }
}