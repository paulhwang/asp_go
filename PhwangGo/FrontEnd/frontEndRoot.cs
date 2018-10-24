using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phwang.FrontEnd
{
    public class FrontEndRootClass
    {
        public FrontEndAjaxParserClass FrontEndAjaxParserObject { get; }
        public FrontEndGoServiceClass FrontEndGoServiceObject { get; }

        public FrontEndRootClass()
        {
            this.FrontEndGoServiceObject = new FrontEndGoServiceClass(this);
            this.FrontEndAjaxParserObject = new FrontEndAjaxParserClass(this);
         }
    }
}
