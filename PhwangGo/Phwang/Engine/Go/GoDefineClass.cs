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
    public class GoDefineClass
    {
        public const int GO_EMPTY_STONE = 0;
        public const int GO_BLACK_STONE = 1;
        public const int GO_WHITE_STONE = 2;
        public const int GO_MARK_DEAD_STONE_DIFF = 4;
        public const int GO_MARK_EMPTY_STONE_DIFF = 8;

        public const int GO_MARKED_DEAD_BLACK_STONE = (GO_BLACK_STONE + GO_MARK_DEAD_STONE_DIFF);
        public const int GO_MARKED_DEAD_WHITE_STONE = (GO_WHITE_STONE + GO_MARK_DEAD_STONE_DIFF);

        public const int GO_MARKED_EMPTY_BLACK_STONE = (GO_BLACK_STONE + GO_MARK_EMPTY_STONE_DIFF);
        public const int GO_MARKED_EMPTY_WHITE_STONE = (GO_WHITE_STONE + GO_MARK_EMPTY_STONE_DIFF);
    }
}
