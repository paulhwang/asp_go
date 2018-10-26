﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phwang.FabricFrontEnd
{
    public class FabricFrontEndProtocolClass
    {
        public const int LINK_MGR_PROTOCOL_TRANSPORT_PORT_NUMBER = 8006;

        //#define LINK_MGR_DATA_BUFFER_SIZE 512

        public const int LINK_MGR_PROTOCOL_LINK_ID_SIZE = 4;
        public const int LINK_MGR_PROTOCOL_LINK_INDEX_SIZE = 4;
        public const int LINK_MGR_PROTOCOL_LINK_ID_INDEX_SIZE = (LINK_MGR_PROTOCOL_LINK_ID_SIZE + LINK_MGR_PROTOCOL_LINK_INDEX_SIZE);

            //#define LINK_MGR_PROTOCOL_SESSION_ID_SIZE 4
            //#define LINK_MGR_PROTOCOL_SESSION_INDEX_SIZE 4
            //#define LINK_MGR_PROTOCOL_SESSION_ID_INDEX_SIZE (LINK_MGR_PROTOCOL_SESSION_ID_SIZE + LINK_MGR_PROTOCOL_SESSION_INDEX_SIZE)
    }
}