using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phwang.FrontEnd
{
    public class FrontEndRootClass
    {
        public FrontEndAjaxParserClass FrontEndAjaxParserObject { get; }
        public FrontEndFabricClass FrontEndGoServiceObject { get; }

        public FrontEndRootClass()
        {
            this.FrontEndGoServiceObject = new FrontEndFabricClass(this);
            this.FrontEndAjaxParserObject = new FrontEndAjaxParserClass(this);
         }
    }
}
