﻿/*
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
    public class GoGroupListClass
    {
        private string objectName = "GoGroupListClass";
        private const int GO_GROUP_LIST_CLASS_GROUP_ARRAY_SIZE = 400;

        private GoFightClass theFightObject { get; }
        private int indexNumber { get; }
        private int myColor { get; }
        int theHisColor;
        private bool isDead { get; }
        private string bigStoneColor { get; }
        private string smallStoneColor { get; }
        private int isMarkedDead { get; }
        private int groupCount { get; set; }
        private GoGroupClass[] groupArray { get; }

        public GoFightClass FightObject() { return this.theFightObject; }
        public GoRootClass RootObject() { return this.theFightObject.RootObject(); }
        public GoBoardClass BoardObject() { return RootObject().BoardObject(); }
        public GoConfigClass ConfigObject() { return RootObject().ConfigObject(); }
        public int MyColor() { return this.myColor; }
        public int GroupCount() { return this.groupCount; }
        public GoGroupClass GroupArray(int index_val) { return this.groupArray[index_val]; }

        public GoGroupListClass(GoFightClass fight_object_val,
                       int index_val,
                       int color_val,
                       bool is_dead_val,
                       string big_stone_val,
                       string small_stone_val)
        {
            this.theFightObject = fight_object_val;
            this.groupArray = new GoGroupClass[GO_GROUP_LIST_CLASS_GROUP_ARRAY_SIZE];
            this.indexNumber = index_val;
            this.myColor = color_val;
            this.isDead = is_dead_val;
            this.bigStoneColor = big_stone_val;
            this.smallStoneColor = small_stone_val;
            this.groupCount = 0;
            this.isMarkedDead = 0;
        }

        public int TotalStoneCount()
        {
            int count = 0;
            for (int i = 0; i < this.groupCount; i++)
            {
                count += this.groupArray[i].StoneCount();
            }
            return count;
        }

        public void InsertGroupToGroupList(GoGroupClass group_val)
        {
            this.groupArray[this.groupCount] = group_val;
            group_val.SetIndexNumber(this.groupCount);
            this.groupCount++;
            group_val.SetGroupListObject(this);
        }

        public GoGroupClass FindCandidateGroup(int x_val, int y_val)
        {
            int i = 0;
            while (i < this.groupCount)
            {
                if (this.groupArray[i].IsCandidateGroup(x_val, y_val))
                {
                    return this.groupArray[i];
                }
                i += 1;
            }
            return null;
        }

        public GoGroupClass FindOtherCandidateGroup(GoGroupClass group_val, int x_val, int y_val)
        {
            int i = 0;
            while (i < this.groupCount)
            {
                if (this.groupArray[i] != group_val)
                {
                    if (this.groupArray[i].IsCandidateGroup(x_val, y_val))
                    {
                        return this.groupArray[i];
                    }
                }
                i += 1;
            }
            return null;
        }

        public void RemoveGroupFromGroupList(GoGroupClass group_val)
        {
            this.groupCount--;
            if (group_val.IndexNumber() != this.groupCount)
            {
                this.groupArray[this.groupCount].SetIndexNumber(group_val.IndexNumber());
                this.groupArray[group_val.IndexNumber()] = this.groupArray[this.groupCount];
            }
            this.groupArray[this.groupCount] = null;
        }

        public bool StoneExistWithinMe(int x_val, int y_val)
        {
            int i = 0;
            while (i < this.groupCount)
            {
                GoGroupClass group = this.groupArray[i];
                if (group.ExistMatrix(x_val, y_val))
                {
                    return true;
                }
                i += 1;
            }
            return false;
        }

        public void AbendGroupList()
        {
            int i = 0;
            while (i < this.groupCount)
            {
                GoGroupClass group = this.groupArray[i];
                if (group == null)
                {
                    this.abendIt("abendGroupList", "null group");
                    return;
                }
                if (group.GroupListObject() != this)
                {
                    this.abendIt("abendGroupList", "groupListObject");
                    return;
                }
                if (group.IndexNumber() != i)
                {
                    this.abendIt("abendGroupList", "index ");
                    return;
                }

                group.AbendGroup();

                int j = i + 1;
                while (j < this.groupCount)
                {
                    group.AbendOnGroupConflict(this.groupArray[j]);
                    j = j + 1;
                }
                i += 1;
            }

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
