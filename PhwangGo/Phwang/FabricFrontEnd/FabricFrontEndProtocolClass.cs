﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phwang.FabricFrontEnd
{
    public class FabricFrontEndProtocolClass
    {
        public const int LINK_MGR_PROTOCOL_TRANSPORT_PORT_NUMBER = 8006;

        public const int AJAX_MAPING_ID_SIZE = 3;
        public const int WEB_FABRIC_PROTOCOL_NAME_LIST_TAG_SIZE = 3;

        //#define WEB_FABRIC_PROTOCOL_RESPOND_IS_GET_LINK_DATA_PENDING_SESSION 'S'
        //#define WEB_FABRIC_PROTOCOL_RESPOND_IS_GET_LINK_DATA_PENDING_SESSION3 'T'
        //#define WEB_FABRIC_PROTOCOL_RESPOND_IS_GET_LINK_DATA_PENDING_DATA 'D'
        public const String WEB_FABRIC_PROTOCOL_RESPOND_IS_GET_LINK_DATA_NAME_LIST = "N";

        //#define LINK_MGR_DATA_BUFFER_SIZE 512

        public const int LINK_MGR_PROTOCOL_LINK_ID_SIZE = 4;
        public const int LINK_MGR_PROTOCOL_LINK_INDEX_SIZE = 4;
        public const int LINK_MGR_PROTOCOL_LINK_ID_INDEX_SIZE = (LINK_MGR_PROTOCOL_LINK_ID_SIZE + LINK_MGR_PROTOCOL_LINK_INDEX_SIZE);

            //#define LINK_MGR_PROTOCOL_SESSION_ID_SIZE 4
            //#define LINK_MGR_PROTOCOL_SESSION_INDEX_SIZE 4
            //#define LINK_MGR_PROTOCOL_SESSION_ID_INDEX_SIZE (LINK_MGR_PROTOCOL_SESSION_ID_SIZE + LINK_MGR_PROTOCOL_SESSION_INDEX_SIZE)
    }
}
