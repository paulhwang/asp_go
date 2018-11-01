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

namespace Phwang.Theme
{
    public class DThemeClass
    {
        private string objectName = "DThemeClass";

        private ThemeRootClass themeRootObject { get; }
        private DThemeParserClass dThemeParserObject { get; }
        private PhwangUtils.BinderClass binderObject { get; }

        public DThemeClass(ThemeRootClass theme_root_object_val)
        {
            this.themeRootObject = theme_root_object_val;
            this.dThemeParserObject = new DThemeParserClass(this);
            this.binderObject = new PhwangUtils.BinderClass(this.objectName);
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
