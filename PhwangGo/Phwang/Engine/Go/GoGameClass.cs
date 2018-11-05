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
    public class GoGameClass
    {
        private string objectName = "GoGameClass";
        private const int GO_GAME_CLASS_MAX_MOVES_ARRAY_SIZE = 1024;

        private GoRootClass rootObject { get; }
        private int totalMoves { get; set; }
        private int maxMove { get; set; }
        private int nextColor { get; set; }
        private bool passReceived { get; set; }
        private bool gameIsOver { get; set; }
        private GoMoveClass[] movesArray { get; }

        public GoBoardClass BoardObject() { return this.rootObject.BoardObject(); }
        public GoFightClass FightObject() { return this.rootObject.FightObject(); }
        public int TotalMoves() { return this.totalMoves; }
        public int NextColor() { return this.nextColor; }

        public GoGameClass(GoRootClass go_root_object_val)
        {
            this.rootObject = go_root_object_val;
            this.movesArray = new GoMoveClass[GO_GAME_CLASS_MAX_MOVES_ARRAY_SIZE];
        }

        public void AddNewMoveAndFight(GoMoveClass move_val)
        {
            this.debugIt(true, "AddNewMoveAndFight", "Move = " + move_val.MoveInfo());

            if (move_val.TurnIndex() != this.totalMoves + 1)
            {
                this.logitIt("AddNewMoveAndFight", "duplicated move received *****************");
                return;
            }

            if (this.gameIsOver)
            {
                this.abendIt("AddNewMoveAndFight", "theGameIsOver");
                return;
            }

            this.passReceived = false;
            this.BoardObject().ClearLastDeadStone();
            this.insertMoveToMoveList(move_val);
            this.FightObject().EnterBattle(move_val);
            this.nextColor = GoDefineClass.GetOppositeColor(move_val.MyColor());
        }

        private void insertMoveToMoveList(GoMoveClass move_val)
        {
            this.movesArray[this.totalMoves] = move_val;
            this.totalMoves++;
            this.maxMove = this.totalMoves;
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
