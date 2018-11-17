/*
  Copyrights reserved
  Written by Paul Hwang
*/
function ThemeMgrClass(root_object_val) {
    "use strict";
    this.init__ = function (root_object_val) {
        this.theRootObject = root_object_val;
        //this.theGoMgrObject = new GoMgrClass(this);
    };
    this.mallocThemeAndInsert = function () {
        var theme = new GoBaseObject(this.rootObject());
        this.theThemeObject = theme;
        return theme;
    };
    this.getTheme = function () {
        return this.theThemeObject;
    };
    this.objectName = function () { return "ThemeMgrClass"; };
    this.rootObject = function () { return this.theRootObject; };
    this.phwangObject = function () { return this.rootObject().phwangObject(); };
    this.debug = function (debug_val, str1_val, str2_val) { if (debug_val) { this.logit(str1_val, str2_val); } };
    this.logit = function (str1_val, str2_val) { return this.rootObject().logit_(this.objectName() + "." + str1_val, str2_val); };
    this.abend = function (str1_val, str2_val) { return this.rootObject().abend_(this.objectName() + "." + str1_val, str2_val); };
    this.init__(root_object_val);
}
