using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phwang.FrontEnd
{
    public class FrontEndRootClass
    {
        public FrontEndAjaxParserClass FabricAjaxParserObject { get; }
        public FrontEndGoServiceClass FabricGoServiceObject { get; }

        public FrontEndRootClass()
        {
            this.FabricGoServiceObject = new FrontEndGoServiceClass(this);
            this.FabricAjaxParserObject = new FrontEndAjaxParserClass(this);
         }
    }
}
