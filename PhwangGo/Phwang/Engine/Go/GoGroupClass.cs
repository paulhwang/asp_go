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
    public class GoGroupClass
    {
        private string objectName = "GoGroupClass";
        GoGroupListClass groupListObject;
        private int maxX { get; set; }
        private int minX { get; set; }
        private int maxY { get; set; }
        private int minY { get; set; }
        //int theDeadMatrix[19][19];
        int theIndexNumber;
        int stoneCount;
        int theMyColor;
        int hisColor { get; set; }
        private bool[,] existMatrix { get; }

        public int HisColor() { return this.hisColor; }
        public int StoneCount() { return this.stoneCount; }
        public bool ExistMatrix(int x_val, int y_val) { return this.existMatrix[x_val, y_val]; }


        public GoGroupClass(GoGroupListClass group_list_object_val)
        {
            this.groupListObject = group_list_object_val;
            this.existMatrix = new bool[GoDefineClass.MAX_BOARD_SIZE, GoDefineClass.MAX_BOARD_SIZE];
        }

        public void InsertStoneToGroup(int x_val, int y_val, bool dead_val)
        {
            /*
            if (this->theExistMatrix[x_val][y_val])
            {
                this->abend("insertStoneToGroup", "stone already exists in group");
            }

            if (this->theStoneCount == 0)
            {
                this->theMaxX = x_val;
                this->theMinX = x_val;
                this->theMaxY = y_val;
                this->theMinY = y_val;
            }
            else
            {
                if (x_val > this->theMaxX)
                {
                    this->theMaxX = x_val;
                }
                if (x_val < this->theMinX)
                {
                    this->theMinX = x_val;
                }
                if (y_val > this->theMaxY)
                {
                    this->theMaxY = y_val;
                }
                if (y_val < this->theMinY)
                {
                    this->theMinY = y_val;
                }
            }

            this->theStoneCount++;
            this->theExistMatrix[x_val][y_val] = true;
            this->theDeadMatrix[x_val][y_val] = dead_val;
            */
        }

        public bool IsCandidateGroup(int x_val, int y_val)
        {
            int i = this.minX;
            while (i <= this.maxX)
            {
                int j = this.minY;
                while (j <= this.maxY)
                {
                    if (this.existMatrix[i, j])
                    {
                        //this.debug(false, "isCandidateGroup", "(" + x_val + "," + y_val + ") (" + i + "," + j + ")");
                        if (GoDefineClass.isNeighborStone(i, j, x_val, y_val))
                        {
                            return true;
                        }
                    }
                    j += 1;
                }
                i += 1;
            }
            return false;
        }

        public void MergeWithOtherGroup(GoGroupClass group2)
        {
            /*
            this->debug(false, "mergeWithOtherGroup", "");
            int i = group2->theMinX;
            while (i <= group2->theMaxX)
            {
                int j = group2->theMinY;
                while (j <= group2->theMaxY)
                {
                    if (group2->theExistMatrix[i][j])
                    {
                        //this.debug(false, "mergeWithOtherGroup", "i=" + i + " j=" + j);
                        if (this->theExistMatrix[i][j])
                        {
                            this->abend("mergeWithOtherGroup", "already exist");
                        }
                        this->theExistMatrix[i][j] = group2->theExistMatrix[i][j];
                        this->theStoneCount++;

                        group2->theExistMatrix[i][j] = 0;
                        group2->theStoneCount--;
                    }
                    j += 1;
                }
                i += 1;
            }
            if (group2->theStoneCount)
            {
                this->abend("mergeWithOtherGroup", "theStoneCount");
            }

            if (this->theMaxX < group2->theMaxX)
            {
                this->theMaxX = group2->theMaxX;
            }
            if (this->theMinX > group2->theMinX)
            {
                this->theMinX = group2->theMinX;
            }
            if (this->theMaxY < group2->theMaxY)
            {
                this->theMaxY = group2->theMaxY;
            }
            if (this->theMinY > group2->theMinY)
            {
                this->theMinY = group2->theMinY;
            }

            if (group2->theGroupListObject->groupArray(group2->theIndexNumber) != group2)
            {
                this->abend("mergeWithOtherGroup", "group2");
            }
            */
        }

        public bool GroupHasAir()
        {
            int i = this.minX;
            while (i <= this.maxX)
            {
                int j = this.minY;
                while (j <= this.maxY)
                {
                    if (this.existMatrix[i, j])
                    {
                        if (this.groupListObject.FightObject().RootObject().BoardObject().StoneHasAir(i, j))
                        {
                            return true;
                        }
                    }
                    j += 1;
                }
                i += 1;
            }
            return false;
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
