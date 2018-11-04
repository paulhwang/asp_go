/*
 ******************************************************************************
 *                                       
 *  Copyright (c) 2018 phwang. All rights reserved.
 *
 ******************************************************************************
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phwang.Go
{
    public class GoFightClass
    {
        private string objectName = "GoFightClass";
        private const int GO_FIGHT_CLASS_GROUP_LIST_ARRAY_SIZE = 7;

        private GoRootClass rootObject { get; }
        private bool abendEngineOn { get; }
        GoGroupListClass[] groupListArray;
        string captureCount { get; set; }
        string lastDeadStone;////////////////to be removed

        public GoBoardClass BoardObject() { return this.rootObject.BoardObject(); }

        public GoFightClass(GoRootClass go_root_object_val)
        {
            this.rootObject = go_root_object_val;
            this.groupListArray = new GoGroupListClass[GO_FIGHT_CLASS_GROUP_LIST_ARRAY_SIZE];
            this.resetEngineObjectData();
        }

        private void resetEngineObjectData()
        {
            this.BoardObject().ResetBoardObjectData();

            this.groupListArray[1] = new GoGroupListClass(this, 1, GoDefineClass.GO_BLACK_STONE, false, null, null);
            this.groupListArray[2] = new GoGroupListClass(this, 2, GoDefineClass.GO_WHITE_STONE, false, null, null);
            this.resetMarkedGroupLists();
            this.resetEmptyGroupLists();

            this.captureCount = null;
            this.lastDeadStone = null;
        }
        private void resetMarkedGroupLists()
        {
            this.groupListArray[3] = new GoGroupListClass(this, 3, GoDefineClass.GO_BLACK_STONE, true, "black", "gray");
            this.groupListArray[4] = new GoGroupListClass(this, 4, GoDefineClass.GO_WHITE_STONE, true, "white", "gray");
            this.BoardObject().ResetMarkedBoardObjectData();
        }

        private void resetEmptyGroupLists()
        {
            this.groupListArray[0] = new GoGroupListClass(this, 0, GoDefineClass.GO_EMPTY_STONE, false, null, null);
            this.groupListArray[5] = new GoGroupListClass(this, 5, GoDefineClass.GO_EMPTY_STONE, false, null, "black");
            this.groupListArray[6] = new GoGroupListClass(this, 6, GoDefineClass.GO_EMPTY_STONE, false, null, "white");
        }

        public void EnterBattle(GoMoveClass move_val)
        {

        }

        private void debugIt(bool on_off_val, string str0_val, string str1_val)
        {
            if (on_off_val)
                this.logitIt(str0_val, str1_val);
        }

        private void logitIt(string str0_val, string str1_val)
        {
            PhwangUtils.AbendClass.phwangLogit(this.objectName + "." + str0_val + "()", str1_val);
        }

        private void abendIt(string str0_val, string str1_val)
        {
            PhwangUtils.AbendClass.phwangAbend(this.objectName + "." + str0_val + "()", str1_val);
        }
    }
}
