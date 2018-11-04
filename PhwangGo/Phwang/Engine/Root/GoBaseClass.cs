using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phwang.Engine
{
    public class GoBaseClass
    {
        private string objectName = "GoBaseClass";

        private PhwangUtils.ListEntryClass listEntryObject;
        private string roomIdStr { get; }
        private int baseId { get; set; }
        private string baseIdStr { get; set; }
        private Go.GoRootClass goRootObject { get; }

        public string RoomIdStr() { return this.roomIdStr; }
        public string BaseIdStr() { return this.baseIdStr; }

        public GoBaseClass(string room_id_str_val)
        {
            this.roomIdStr = room_id_str_val;
            this.goRootObject = new Go.GoRootClass();
        }

        public string SetupBase(string input_data_val)
        {
            return null;
        }

        public string ProcessInputData(string input_data_val)
        {
            return "GO DATA";
        }

        public void BindListEntry(PhwangUtils.ListEntryClass list_entry_objectg_val)
        {
            this.listEntryObject = list_entry_objectg_val;
            this.baseId = this.listEntryObject.Id;
            this.baseIdStr = PhwangUtils.EncodeNumberClass.EncodeNumber(this.baseId, Protocols.ThemeEngineProtocolClass.ENGINE_BASE_ID_SIZE);
        }
    }
}
