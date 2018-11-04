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
        public GoConfigClass ConfigObject() { return this.rootObject.ConfigObject(); }

        GoGroupListClass emptyGroupList() { return this.groupListArray[0]; }
        GoGroupListClass blackGroupList() { return this.groupListArray[1]; }
        GoGroupListClass whiteGroupList() { return this.groupListArray[2]; }
        GoGroupListClass blackDeadGroupList() { return this.groupListArray[3]; }
        GoGroupListClass whiteDeadGroupList() { return this.groupListArray[4]; }
        GoGroupListClass blackEmptyGroupList() { return this.groupListArray[5]; }
        GoGroupListClass whiteEmptyGroupList() { return this.groupListArray[6]; }

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
            GoGroupListClass g_list;

            if (move_val.MyColor() == GoDefineClass.GO_BLACK_STONE)
            {
                g_list = this.blackGroupList();
            }
            else if (move_val.MyColor() == GoDefineClass.GO_WHITE_STONE)
            {
                g_list = this.whiteGroupList();
            }
            else
            {
                this.abendIt("insertStoneToGroupList", move_val.MoveInfo());
                return null;
            }

            GoGroupClass group = g_list.FindCandidateGroup(move_val.XX(), move_val.YY());
            if (group == null)
            {
                group = new GoGroupClass(g_list);
                group.InsertStoneToGroup(move_val.XX(), move_val.YY(), false);
                g_list.InsertGroupToGroupList(group);
                return group;
            }

            group.InsertStoneToGroup(move_val.XX(), move_val.YY(), false);

            int dummy_count = 0;
            GoGroupClass group2;
            while (true)
            {
                group2 = g_list.FindOtherCandidateGroup(group, move_val.XX(), move_val.YY());
                if (group2 == null)
                {
                    break;
                }
                dummy_count += 1;
                group.MergeWithOtherGroup(group2);
                g_list.RemoveGroupFromGroupList(group2);
            }
            if (dummy_count > 3)
            {
                this.abendIt("insertStoneToGroupList", "dummy_count");
            }
            return group;
        }

        private int killOtherColorGroups(GoMoveClass move_val, GoGroupClass my_group_val)
        {
            int count;
            count = this.killOtherColorGroup(my_group_val, move_val.XX() - 1, move_val.YY());
            count += this.killOtherColorGroup(my_group_val, move_val.XX() + 1, move_val.YY());
            count += this.killOtherColorGroup(my_group_val, move_val.XX(), move_val.YY() - 1);
            count += this.killOtherColorGroup(my_group_val, move_val.XX(), move_val.YY() + 1);
            return count;
        }

        private int killOtherColorGroup(GoGroupClass my_group_val, int x_val, int y_val)
        {
            GoGroupClass his_group;

            if (!this.ConfigObject().IsValidCoordinates(x_val, y_val))
            {
                return 0;
            }

            if (this.BoardObject().BoardArray(x_val, y_val) != my_group_val.HisColor())
            {
                return 0;
            }

            his_group = this.getGroupByCoordinate(x_val, y_val, my_group_val.HisColor());
            if (his_group == null)
            {
                this.abendIt("killOtherColorGroup", "null his_group");
                return 0;
            }

            if (his_group.GroupHasAir())
            {
                return 0;
            }

            int dead_count = his_group.StoneCount();
            if ((my_group_val.StoneCount() == 1) && (his_group.StoneCount() == 1))
            {
                this.markLastDeadInfo(his_group);
            }

            this.removeDeadGroup(his_group);
            return dead_count;
        }

        private GoGroupClass getGroupByCoordinate(int x_val, int y_val, int color_val)
        {
            GoGroupListClass g_list;
            if ((color_val == GoDefineClass.GO_BLACK_STONE) || (color_val == GoDefineClass.GO_MARKED_DEAD_BLACK_STONE))
            {
                g_list = this.blackGroupList();
            }
            else
            {
                g_list = this.whiteGroupList();
            }

            for (int i = 0; i < g_list.GroupCount(); i++)
            {
                if (g_list.GroupArray(i).ExistMatrix(x_val, y_val))
                {
                    return g_list.GroupArray(i);
                }
            }
            return null;
        }

        private void removeDeadGroup(GoGroupClass group)
        {
            group.RemoveDeadStoneFromBoard();
            if (group.MyColor() == GoDefineClass.GO_BLACK_STONE)
            {
                this.blackGroupList().RemoveGroupFromGroupList(group);
            }
            else
            {
                this.whiteGroupList().RemoveGroupFromGroupList(group);
            }
         }

        private void markLastDeadInfo(GoGroupClass group_val)
        {
            /*
            this->theBaseObject->boardObject()->setLastDeadStone(group_val->maxX(), group_val->maxY());

            if (group_val->maxX() != group_val->minX())
            {
                this->abend("markLastDeadInfo", "bad x");
            }
            if (group_val->maxY() != group_val->minY())
            {
                this->abend("markLastDeadInfo", "bad y");
            }
            if (!group_val->existMatrix(group_val->maxX(), group_val->maxY()))
            {
                this->abend("markLastDeadInfo", "exist_matrix");
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
