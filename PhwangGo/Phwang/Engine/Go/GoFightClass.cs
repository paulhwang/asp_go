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

        public GoRootClass RootObject() { return this.rootObject; }
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
            this.debugIt(true, "enterBattle", move_val.MoveInfo());

            this.BoardObject().AddStoneToBoard(move_val.XX(), move_val.YY(), move_val.MyColor());
            GoGroupClass my_group = this.insertStoneToGroupList(move_val);
            if (my_group == null)
            {
                this.abendIt("enterBattle", "fail in insertStoneToGroupList");
                return;
            }

            int dead_count = this.killOtherColorGroups(move_val, my_group);

            if (!my_group.GroupHasAir())
            {
                this.removeDeadGroup(my_group);
            }

            if (dead_count != 0)
            {
                if (move_val.MyColor() == GoDefineClass.GO_BLACK_STONE)
                {
                    this.BoardObject().AddBlackCapturedStones(dead_count);
                }
                else if (move_val.MyColor() == GoDefineClass.GO_WHITE_STONE)
                {
                    this.BoardObject().AddWhiteCapturedStones(dead_count);
                }
                else
                {
                    this.abendIt("enterBattle", "bad color");
                }
            }
            this.abendEngine();
        }

        private GoGroupClass insertStoneToGroupList(GoMoveClass move_val)
        {
            /*
            GoGroupListClass* g_list;

            if (move_val->myColor() == GO_BLACK_STONE)
            {
                g_list = this->blackGroupList();
            }
            else if (move_val->myColor() == GO_WHITE_STONE)
            {
                g_list = this->whiteGroupList();
            }
            else
            {
                this->abend("insertStoneToGroupList", move_val->moveInfo());
                return 0;
            }

            GoGroupClass* group = g_list->findCandidateGroup(move_val->xX(), move_val->yY());
            if (!group)
            {
                group = new GoGroupClass(g_list);
                group->insertStoneToGroup(move_val->xX(), move_val->yY(), false);
                g_list->insertGroupToGroupList(group);
                return group;
            }

            group->insertStoneToGroup(move_val->xX(), move_val->yY(), false);

            int dummy_count = 0;
            GoGroupClass* group2;
            while (1)
            {
                group2 = g_list->findOtherCandidateGroup(group, move_val->xX(), move_val->yY());
                if (!group2)
                {
                    break;
                }
                dummy_count += 1;
                group->mergeWithOtherGroup(group2);
                g_list->removeGroupFromGroupList(group2);
            }
            if (dummy_count > 3)
            {
                this->abend("insertStoneToGroupList", "dummy_count");
            }
            return group;
            */
            return null;
        }

        private int killOtherColorGroups(GoMoveClass move_val, GoGroupClass my_group_val)
        {
            /*
            int count;
            count = this->killOtherColorGroup(my_group_val, move_val->xX() - 1, move_val->yY());
            count += this->killOtherColorGroup(my_group_val, move_val->xX() + 1, move_val->yY());
            count += this->killOtherColorGroup(my_group_val, move_val->xX(), move_val->yY() - 1);
            count += this->killOtherColorGroup(my_group_val, move_val->xX(), move_val->yY() + 1);
            return count;
            */
            return 0;
        }

        private void removeDeadGroup(GoGroupClass group)
        {
            /*
            group->removeDeadStoneFromBoard();
            if (group->myColor() == GO_BLACK_STONE)
            {
                this->blackGroupList()->removeGroupFromGroupList(group);
            }
            else
            {
                this->whiteGroupList()->removeGroupFromGroupList(group);
            }
            */
        }

        private void abendEngine()
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
