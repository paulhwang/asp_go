﻿/*
  Copyrights reserved
  Written by Paul Hwang
*/
function ThemeMgrClass(root_object_val) {
    "use strict";
    this.init__ = function (root_object_val) {
        this.theRootObject = root_object_val;
        this.theGlobalThemeId = this.INITIAL_THEME_ID();
        this.theThemeIndexArray = [0];
        this.theThemeTableArray = [null];
    };
    this.themeIndexArray = function () { return this.theThemeIndexArray; };
    this.themeTableArray = function () { return this.theThemeTableArray; };
    this.themeTableArrayLength = function () { return this.themeTableArray().length; };
    this.themeTableArrayElement = function (val) { return this.themeTableArray()[val]; };
    this.mallocThemeAndInsert = function () {
        var theme = new GoBaseObject(this.rootObject(), this.phwangObject().encodeNumber(this.assignThemeId(), this.THEME_ID_STR_SIZE()));
        this.insertTheme(theme);
        this.theThemeObject = theme;
        return theme;
    };
    this.insertTheme = function (theme_val) {
        this.themeIndexArray().push(theme_val.themeIdStr());
        this.themeTableArray().push(theme_val);
    };
    this.getTheme = function (theme_id_str_val) {
        if (theme_id_str_val === null) {
            this.abend("getTheme", "null");
            return this.theThemeObject;
        }
        if (theme_id_str_val === "undifined") {
            this.abend("getTheme", "null");
            return this.theThemeObject;
        }

        this.debug(true, "getTheme", "theme_id_str_val=" + theme_id_str_val);
        var index = this.themeIndexArray().indexOf(theme_id_str_val);
        if (index === -1) {
            this.abend("getTheme", "not found");
            return null;
        } else {
            var theme = this.themeTableArray()[index];
            return theme;
        }
    };
    this.assignThemeId = function () {
        this.theGlobalThemeId++;
        if (this.theGlobalThemeId === this.MAX_THEME_ID()) {
            this.theGlobalThemeId = this.INITIAL_THEME_ID();
        }
        return this.theGlobalThemeId;
    }
    this.objectName = function () { return "ThemeMgrClass"; };
    this.rootObject = function () { return this.theRootObject; };
    this.phwangObject = function () { return this.rootObject().phwangObject(); };
    this.phwangAjaxObject = function () { return this.phwangObject().phwangAjaxObject(); };
    this.phwangAjaxProtocolObject = function () { return this.phwangAjaxObject().phwangAjaxProtocolObject(); };
    this.debug = function (debug_val, str1_val, str2_val) { if (debug_val) { this.logit(str1_val, str2_val); } };
    this.logit = function (str1_val, str2_val) { return this.rootObject().logit_(this.objectName() + "." + str1_val, str2_val); };
    this.abend = function (str1_val, str2_val) { return this.rootObject().abend_(this.objectName() + "." + str1_val, str2_val); };
    this.INITIAL_THEME_ID = function () { return 2000; };
    this.MAX_THEME_ID = function () { return 10000; }
    this.THEME_ID_STR_SIZE = function () { return this.phwangAjaxProtocolObject().WEB_FABRIC_PROTOCOL_THEME_ID_SIZE(); };
    this.init__(root_object_val);
}
