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
    public class GoBoardClass
    {
        private string objectName = "GoBoardClass";

        private int[,] boardArray { get; }
        private int[,] markedBoardArray { get; }
        //char theBoardOutputBuffer[1 + 3 + 1 + 19 * 19 + 3 * 2 + 2 * 2 + 32];
        int blackCapturedStones { get; set; }
        int whiteCapturedStones { get; set; }
        int lastDeadX { get; set; }
        int lastDeadY { get; set; }

        private GoRootClass rootObject { get; }

        public GoConfigClass ConfigObject() { return this.rootObject.ConfigObject(); }
        public int BoardArray(int x_val, int y_val) { return this.boardArray[x_val, y_val]; }
        public void AddBlackCapturedStones(int val) { this.blackCapturedStones += val; }
        public void AddWhiteCapturedStones(int val) { this.whiteCapturedStones += val; }
        public void SetBoardArray(int x_val, int y_val, int data_val) { this.boardArray[x_val, y_val] = data_val; }
        public void SetLastDeadStone(int x_val, int y_val) { this.lastDeadX = x_val; this.lastDeadY = y_val; }

        public GoBoardClass(GoRootClass root_object_val)
        {
            this.rootObject = root_object_val;

            this.boardArray = new int[GoDefineClass.MAX_BOARD_SIZE, GoDefineClass.MAX_BOARD_SIZE];
            this.markedBoardArray = new int[GoDefineClass.MAX_BOARD_SIZE, GoDefineClass.MAX_BOARD_SIZE];
            this.ClearLastDeadStone();
        }

        public void AddStoneToBoard(int x_val, int y_val, int color_val)
        {
            if (!this.ConfigObject().IsValidCoordinates(x_val, y_val))
            {
                this.abendIt("addStoneToBoard", "bad coordinate");
                return;
            }

            this.boardArray[x_val, y_val] = color_val;
        }

        private bool isEmptySpace(int x_val, int y_val)
        {
            if (!this.rootObject.ConfigObject().IsValidCoordinates(x_val, y_val))
            {
                return false;
            }
            if (this.boardArray[x_val, y_val] != GoDefineClass.GO_EMPTY_STONE)
            {
                return false;
            }
            return true;
        }

        public bool StoneHasAir(int x_val, int y_val)
        {
            if (this.isEmptySpace(x_val, y_val - 1))
            {
                return true;
            }
            if (this.isEmptySpace(x_val, y_val + 1))
            {
                return true;
            }
            if (this.isEmptySpace(x_val - 1, y_val))
            {
                return true;
            }
            if (this.isEmptySpace(x_val + 1, y_val))
            {
                return true;
            }
            return false;
        }

        public void ResetBoardObjectData()
        {
            int board_size = this.ConfigObject().BoardSize();
            for (int i = 0; i < board_size; i++)
            {
                for (int j = 0; j < board_size; j++)
                {
                    this.boardArray[i, j] = GoDefineClass.GO_EMPTY_STONE;
                    this.markedBoardArray[i, j] = GoDefineClass.GO_EMPTY_STONE;
                }
            }
            this.blackCapturedStones = 0;
            this.whiteCapturedStones = 0;
            this.ClearLastDeadStone();
        }

        public void ResetMarkedBoardObjectData()
        {

        }

        public void ClearLastDeadStone()
        {
            this.lastDeadX = 19;
            this.lastDeadY = 19;
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
